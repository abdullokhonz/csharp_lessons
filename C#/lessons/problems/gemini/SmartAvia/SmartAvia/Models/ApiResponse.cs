namespace SmartAvia.Models
{
    public class ApiResponse
    {
        public string BaseCode { get; set; } = string.Empty;

        public Dictionary<string, decimal>? Rates { get; set; }
    }
}
