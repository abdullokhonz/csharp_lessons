namespace SmartDelivery.Models
{
    public class ExchangeRateResponse
    {
        public string BaseCode { get; set; } = string.Empty;

        public Dictionary<string, decimal>? Rates { get; set; }
    }
}
