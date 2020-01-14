using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cloner.Common
{
    public partial class MessageData
    {
        public partial class Message
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public long Type { get; set; }

            [JsonProperty("content")]
            public string Content { get; set; }

            [JsonProperty("channel_id")]
            public string ChannelId { get; set; }

            [JsonProperty("author")]
            public UserClass Author { get; set; }

            [JsonProperty("attachments")]
            public List<Attachment> Attachments { get; set; }

            [JsonProperty("embeds")]
            public List<Embed> Embeds { get; set; }

            [JsonProperty("mentions")]
            public List<UserClass> Mentions { get; set; }

            [JsonProperty("mention_roles")]
            public List<string> MentionRoles { get; set; }

            [JsonProperty("pinned")]
            public bool Pinned { get; set; }

            [JsonProperty("mention_everyone")]
            public bool MentionEveryone { get; set; }

            [JsonProperty("tts")]
            public bool Tts { get; set; }

            [JsonProperty("timestamp")]
            public DateTimeOffset Timestamp { get; set; }

            [JsonProperty("edited_timestamp")]
            public DateTimeOffset? EditedTimestamp { get; set; }

            [JsonProperty("flags")]
            public long Flags { get; set; }

            [JsonProperty("reactions", NullValueHandling = NullValueHandling.Ignore)]
            public List<Reaction> Reactions { get; set; }

            [JsonProperty("webhook_id", NullValueHandling = NullValueHandling.Ignore)]
            public string WebhookId { get; set; }
        }

        public partial class Attachment
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("filename")]
            public string Filename { get; set; }

            [JsonProperty("size")]
            public long Size { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("proxy_url")]
            public Uri ProxyUrl { get; set; }

            [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
            public long? Width { get; set; }

            [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
            public long? Height { get; set; }
        }

        public partial class UserClass
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("avatar")]
            public string Avatar { get; set; }

            [JsonProperty("discriminator")]
            public string Discriminator { get; set; }

            [JsonProperty("bot", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Bot { get; set; }
        }

        public partial class Embed
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            public string Title { get; set; }

            [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
            public long? Color { get; set; }

            [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
            public List<Field> Fields { get; set; }

            [JsonProperty("footer", NullValueHandling = NullValueHandling.Ignore)]
            public Footer Footer { get; set; }

            [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
            public string Description { get; set; }

            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri Url { get; set; }

            [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
            public Thumbnail Thumbnail { get; set; }

            [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
            public DateTimeOffset? Timestamp { get; set; }

            [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
            public EmbedAuthor Author { get; set; }

            [JsonProperty("provider", NullValueHandling = NullValueHandling.Ignore)]
            public Provider Provider { get; set; }

            [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
            public Video Video { get; set; }

            [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
            public Image Image { get; set; }
        }

        public partial class EmbedAuthor
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri IconUrl { get; set; }

            [JsonProperty("proxy_icon_url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri ProxyIconUrl { get; set; }

            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri Url { get; set; }
        }

        public partial class Field
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("inline")]
            public bool Inline { get; set; }
        }

        public partial class Footer
        {
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        public partial class Image
        {
            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("proxy_url")]
            public Uri ProxyUrl { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }
        }

        public partial class Provider
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }
        }

        public partial class Thumbnail
        {
            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("proxy_url")]
            public Uri ProxyUrl { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }
        }

        public partial class Video
        {
            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("proxy_url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri ProxyUrl { get; set; }
        }

        public partial class Reaction
        {
            [JsonProperty("emoji")]
            public ReactionEmoji Emoji { get; set; }

            [JsonProperty("count")]
            public long Count { get; set; }

            [JsonProperty("me")]
            public bool Me { get; set; }
        }

        public partial class ReactionEmoji
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("animated", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Animated { get; set; }
        }
    }
}
