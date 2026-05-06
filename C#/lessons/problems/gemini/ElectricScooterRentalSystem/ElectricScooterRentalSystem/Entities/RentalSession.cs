namespace ElectricScooterRentalSystem.Entities
{
    public class RentalSession
    {
        public int ScooterId { get; set; }

        public int UserId { get; set; }

        public TimeSpan StarTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
