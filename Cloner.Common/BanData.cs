using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloner.Common
{
    public class BanData
    {
        public partial class Ban
        {
            [JsonProperty("user")]
            public BanUser User { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }
        }

        public partial class BanUser
        {
            [JsonProperty("id")]
            public ulong Id { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("avatar")]
            public string Avatar { get; set; }

            [JsonProperty("discriminator")]
            public string Discriminator { get; set; }

            [JsonProperty("bot", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Bot { get; set; }
        }
    }
}
