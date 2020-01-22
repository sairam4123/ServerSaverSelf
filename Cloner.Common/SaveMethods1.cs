using Discord;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Cloner.Common;

namespace Cloner.Common
{
    public partial class SaveMethods1
    {
        public static event EventHandler<string> Log;
        private static void LogMethod(string content)
        {
            Log?.Invoke(typeof(SaveMethods1), content);
        }


        public static async Task<Save> FromToken(bool bot, string token, ulong guildId, HttpClient httpClient)
        {
            LogMethod("Verifying Token...");

            var userId = await VerifyToken(bot, token, httpClient);
            if (userId == null)
            {
                throw new Exception("Invalid Token Provided, failed @me check");
            }

            var guildEndpoint = Save.ApiEndpoint + "/guilds/" + guildId;
            var banEndPoint = guildEndpoint + "/bans";

            var save = new Save
            {
                SaveVersion = 1,
                SavedBy = userId.Value,
                SaveTime = DateTime.UtcNow.Ticks
            };

            LogMethod("Attempting to save guild (server) information...");
            var guild = await RequestAndParse<GuildParentData.Guild>(bot, token, Save.ApiEndpoint + "/guilds/" + guildId, httpClient);
            save.Guild = guild ?? throw new Exception("User is not a member of the requested guild");

            bool readMessages = true;
            bool viewBans = true;
            //Requesting the members endpoint via a user token will trigger an automatic verification email from discord
            if (bot)
            {
                //Batches member requests for the guild as the max per request is 1000.
                ulong? lastMemberId = null;
                save.Members = new List<MemberData.Member>();
                LogMethod("Saving Members...");
                do
                {
                    List<MemberData.Member> memberChunk;
                    if (lastMemberId != null)
                    {
                        memberChunk = await RequestAndParse<List<MemberData.Member>>(bot, token, guildEndpoint + "/members?limit=1000&after=" + lastMemberId, httpClient);
                    }
                    else
                    {
                        memberChunk = await RequestAndParse<List<MemberData.Member>>(bot, token, guildEndpoint + "/members?limit=1000", httpClient);
                    }

                    if (memberChunk == null) break;

                    if (memberChunk.Count >= 999)
                    {
                        var lastMember = memberChunk.Last();
                        lastMemberId = ulong.Parse(lastMember.User.Id);
                    }
                    else
                    {
                        lastMemberId = null;
                    }

                    save.Members.AddRange(memberChunk);
                }
                while (lastMemberId != null);
                //TODO: MoreLinq Distinctby, ensure save.Members unique by id

                var userMember = save.Members.FirstOrDefault(x => ulong.Parse(x.User.Id) == userId);
                var userRoleObjects = guild.Roles.Where(x => userMember.GetRoleIds().Contains(x.Id));
                var maxPos = userRoleObjects.Max(x => x.Position);
                var maxRole = userRoleObjects.First(x => x.Position == maxPos);
                var guildPermissions = new GuildPermissions((ulong)maxRole.Permissions);

                readMessages = guildPermissions.ViewChannel;
                viewBans = guildPermissions.BanMembers;
            }

            LogMethod("Saving Channels...");
            var channels = await RequestAndParse<List<ChannelData.Channel>>(bot, token, guildEndpoint + "/channels", httpClient);
            save.Channels = channels ?? throw new Exception("Channels returned invalid.");

            save.ChannelMessages = new Dictionary<ulong, List<MessageData.Message>>();
            foreach (var channel in save.Channels)
            {
                /*
                bool canRead = readMessages;
                foreach (var overwrite in channel.PermissionOverwrites)
                {
                    if (overwrite.Type == "member" && ulong.Parse(overwrite.Id) == userId)
                    {
                        
                    }
                    var perm = GetValue((ulong)overwrite.Deny, ChannelPermission.ViewChannel);
                }
                */
                if (channel.Type == (int)ChannelType.Text)
                {
                    LogMethod($"Saving Messages for {channel.Name}...");
                    List<MessageData.Message> messages;
                    if (bot)
                    {
                        messages = await RequestAndParse<List<MessageData.Message>>(bot, token, Save.ApiEndpoint + "/channels/" + channel.Id + "/messages?limit=100", httpClient);
                    }
                    else
                    {
                        messages = await RequestAndParse<List<MessageData.Message>>(bot, token, Save.ApiEndpoint + "/channels/" + channel.Id + "/messages?limit=50", httpClient);
                    }

                    if (messages != null)
                    {
                        save.ChannelMessages.Add(channel.Id, messages);
                    }
                }
            }

            if (viewBans)
            {
                LogMethod("Saving Bans...");
                save.Bans = await RequestAndParse<List<BanData.Ban>>(bot, token, guildEndpoint + "/bans", httpClient);
            }

            return save;
        }

        private static async Task<T> RequestAndParse<T>(bool bot, string token, string uri, HttpClient httpClient) where T : class
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                if (bot)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bot", token);
                }
                else
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue(token);
                }
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await httpClient.SendAsync(request);
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    var content = await response.Content.ReadAsStringAsync();
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(content);
                    }
                    catch
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    LogMethod(e.ToString());
                    throw;
                }
            }
        }
        private static async Task<ulong?> VerifyToken(bool bot, string token, HttpClient httpClient)
        {
            var request = await RequestAndParse<Save.MeData>(bot, token, Save.ApiEndpoint + "/users/@me", httpClient);
            return request?.Id;
        }
    }
}
