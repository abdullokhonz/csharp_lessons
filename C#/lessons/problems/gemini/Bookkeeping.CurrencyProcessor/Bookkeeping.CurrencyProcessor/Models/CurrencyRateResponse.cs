using System.Text.Json.Serialization;

namespace Bookkeeping.CurrencyProcessor.Models
{
    // Названия свойств должны совпадать с JSON от open.er-api.com
    public class CurrencyRateResponse
    {
        [JsonPropertyName("base_code")]
        public string BaseCurrency { get; set; } = string.Empty;

        [JsonPropertyName("rates")]
        public Dictionary<string, decimal>? Rates { get; set; }
    }
}
