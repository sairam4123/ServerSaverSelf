using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloner.Common
{
    public partial class ChannelData
    {
        public partial class Channel
        {
            [JsonProperty("id")]
            public ulong Id { get; set; }

            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("position")]
            public int Position { get; set; }

            [JsonProperty("parent_id", NullValueHandling = NullValueHandling.Ignore)]
            public ulong? ParentId { get; set; }

            [JsonProperty("permission_overwrites")]
            public List<PermissionOverwrite> PermissionOverwrites { get; set; }

            [JsonProperty("nsfw")]
            public bool Nsfw { get; set; }

            [JsonProperty("bitrate", NullValueHandling = NullValueHandling.Ignore)]
            public int? Bitrate { get; set; }

            [JsonProperty("user_limit", NullValueHandling = NullValueHandling.Ignore)]
            public int? UserLimit { get; set; }

            [JsonProperty("last_message_id", NullValueHandling = NullValueHandling.Ignore)]
            public ulong? LastMessageId { get; set; }

            [JsonProperty("topic")]
            public string Topic { get; set; }

            [JsonProperty("rate_limit_per_user", NullValueHandling = NullValueHandling.Ignore)]
            public int? RateLimitPerUser { get; set; }

            [JsonProperty("last_pin_timestamp", NullValueHandling = NullValueHandling.Ignore)]
            public DateTimeOffset? LastPinTimestamp { get; set; }
        }

        public partial class PermissionOverwrite
        {
            [JsonProperty("id")]
            public ulong Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("allow")]
            public ulong Allow { get; set; }

            [JsonProperty("deny")]
            public ulong Deny { get; set; }
        }
    }
}
