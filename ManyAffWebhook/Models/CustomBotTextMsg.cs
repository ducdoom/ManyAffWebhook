using System.Text.Json.Serialization;

namespace ManyAffWebhook.Models
{
    public class CustomBotTextMsg
    {
        [JsonPropertyName("msg_type")]
        public string MsgType { get; set; } = "text";

        [JsonPropertyName("content")]
        public Content Content { get; set; } = new();
    }

    public class Content
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }
}
