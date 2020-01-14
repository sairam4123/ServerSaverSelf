using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloner.Common
{
    public partial class GuildParentData
    {
        public partial class Guild
        {
            [JsonProperty("id")]
            public ulong Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("splash")]
            public string Splash { get; set; }

            [JsonProperty("discovery_splash")]
            public string DiscoverySplash { get; set; }

            [JsonProperty("features")]
            public List<string> Features { get; set; }
            //TODO: Utilize this to set banner, animated icon, news channels, commerce channels, invite splash

            [JsonProperty("emojis")]
            public List<EmojiElement> Emojis { get; set; }

            [JsonProperty("banner")]
            public string Banner { get; set; }

            [JsonProperty("owner_id")]
            public ulong? OwnerId { get; set; }

            [JsonProperty("application_id")]
            public ulong? ApplicationId { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("afk_channel_id")]
            public ulong? AfkChannelId { get; set; }

            [JsonProperty("afk_timeout")]
            public int AfkTimeout { get; set; }

            [JsonProperty("system_channel_id")]
            public ulong? SystemChannelId { get; set; }

            [JsonProperty("widget_enabled")]
            public bool WidgetEnabled { get; set; }

            [JsonProperty("widget_channel_id")]
            public ulong? WidgetChannelId { get; set; }

            [JsonProperty("verification_level")]
            public int VerificationLevel { get; set; }

            [JsonProperty("roles")]
            public List<Role> Roles { get; set; }

            [JsonProperty("default_message_notifications")]
            public int DefaultMessageNotifications { get; set; }

            [JsonProperty("mfa_level")]
            public int MfaLevel { get; set; }

            [JsonProperty("explicit_content_filter")]
            public int ExplicitContentFilter { get; set; }

            [JsonProperty("max_presences")]
            public int? MaxPresences { get; set; }

            [JsonProperty("max_members")]
            public ulong MaxMembers { get; set; }

            [JsonProperty("vanity_url_code")]
            public string VanityUrlCode { get; set; }

            [JsonProperty("premium_tier")]
            public ulong PremiumTier { get; set; }

            [JsonProperty("premium_subscription_count")]
            public int PremiumSubscriptionCount { get; set; }

            //[JsonProperty("system_channel_flags")]
            //public ulong SystemChannelFlags { get; set; }

            [JsonProperty("preferred_locale")]
            public string PreferredLocale { get; set; }

            [JsonProperty("rules_channel_id")]
            public ulong? RulesChannelId { get; set; }

            [JsonProperty("embed_enabled")]
            public bool EmbedEnabled { get; set; }

            [JsonProperty("embed_channel_id")]
            public ulong? EmbedChannelId { get; set; }
        }

        public partial class EmojiElement
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("roles")]
            public List<object> Roles { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("require_colons")]
            public bool RequireColons { get; set; }

            [JsonProperty("managed")]
            public bool Managed { get; set; }

            [JsonProperty("animated")]
            public bool Animated { get; set; }

            [JsonProperty("available")]
            public bool Available { get; set; }
        }

        public partial class Role
        {
            [JsonProperty("id")]
            public ulong Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("permissions")]
            public ulong Permissions { get; set; }

            [JsonProperty("position")]
            public int Position { get; set; }

            [JsonProperty("color")]
            public uint Color { get; set; }

            [JsonProperty("hoist")]
            public bool Hoist { get; set; }

            [JsonProperty("managed")]
            public bool Managed { get; set; }

            [JsonProperty("mentionable")]
            public bool Mentionable { get; set; }
        }
    }
}
