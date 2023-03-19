using System.Text.Json.Serialization;

namespace ThinkBridge.ShopBridge.WebAPI.Settings
{
    public class DomainSettings
    {
        [JsonPropertyName("DatabaseSettings")]
        public DatabaseSettings DatabaseSettings { get; set; } = new DatabaseSettings();
    }
}
