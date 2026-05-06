using ElectricScooterRentalSystem.Entities;

namespace ElectricScooterRentalSystem.Services
{
    public class RentalService
    {
        private readonly List<Scooter> _scooters;
        private readonly List<RentalSession> _rentalSessions;

        public RentalService()
        {
            _scooters = new List<Scooter>();
            _rentalSessions = new List<RentalSession>();
        }

        public void AddScooter(Scooter scooter)
        {
            _scooters.Add(scooter);
        }

        public void StartRental(int scooterId, int userId)
        {
            var scooter = _scooters.FirstOrDefault(s => s.Id == scooterId && s.IsAvailable);

            if (scooter == null)
            {
                throw new InvalidOperationException("Scooter is not available for rental.");
            }

            scooter.IsAvailable = false;

            var rentalSession = new RentalSession
            {
                ScooterId = scooterId,
                UserId = userId,
                StarTime = DateTime.Now.TimeOfDay
            };

            _rentalSessions.Add(rentalSession);
        }

        public void EndRental(int scooterId, int userId)
        {
            var rentalSession = _rentalSessions.FirstOrDefault(rs => rs.ScooterId == scooterId && rs.UserId == userId);

            if (rentalSession == null)
            {
                throw new InvalidOperationException("No active rental session found for this scooter and user.");
            }

            rentalSession.EndTime = DateTime.Now.TimeOfDay;

            var scooter = _scooters.FirstOrDefault(s => s.Id == scooterId);

            if (scooter != null)
            {
                scooter.IsAvailable = true;
                // Simulate battery consumption
                scooter.BatteryLevel -= 10; // Decrease battery level by 10% for each rental
                if (scooter.BatteryLevel < 0) scooter.BatteryLevel = 0; // Ensure battery level doesn't go below 0
            }
        }

        public decimal CalculateCost(DateTime start, DateTime end)
        {
            TimeSpan duration = end - start - TimeSpan.FromMinutes(5);

            if (duration.TotalMinutes < 0)
            {
                duration = TimeSpan.Zero;
            }

            decimal cost = (decimal)Math.Ceiling(duration.TotalMinutes) * 0.10m + 0.50m; // Assuming 0.1 currency units per minute
            return cost;
        }
    }
}
