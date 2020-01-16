using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cloner.Common
{
    public static class Extensions
    {
        public static List<ulong> GetRoleIds(this MemberData.Member member)
        {
            return member.Roles.Select(x => ulong.Parse(x)).ToList();
        }

        public static string ToCompressedString(this Save save)
        {
            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + $"{guild.Id}-{save.SaveTime}.json", StringCompressor.CompressString(JsonConvert.SerializeObject(save)));
            return StringCompressor.CompressString(JsonConvert.SerializeObject(save));
        }

        public static string Filter(this string content)
        {
            return Regex.Replace(content, @"[^a-zA-Z0-9-]", "");
        }
    }
}
