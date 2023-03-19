using System.Text.Json.Serialization;

namespace ThinkBridge.ShopBridge.WebAPI.Settings
{
    public class DatabaseSettings
    {
        [JsonPropertyName("ConnectionString")]
        public string ConnectionString { get; set; }
    }
}
