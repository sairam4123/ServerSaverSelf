using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloner.Common
{
    public partial class MemberData
    {
        public partial class Member
        {
            [JsonProperty("user")]
            public MemberUser User { get; set; }

            //List of role ids as strings
            [JsonProperty("roles")]
            public List<string> Roles { get; set; }

            [JsonProperty("nick")]
            public string Nick { get; set; }

            [JsonProperty("premium_since")]
            public object PremiumSince { get; set; }

            [JsonProperty("mute")]
            public bool Mute { get; set; }

            [JsonProperty("deaf")]
            public bool Deaf { get; set; }

            [JsonProperty("joined_at")]
            public DateTimeOffset JoinedAt { get; set; }
        }

        public partial class MemberUser
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("avatar")]
            public string Avatar { get; set; }

            [JsonProperty("discriminator")]
            public string Discriminator { get; set; }
        }
    }
}
