using AccessControlSystem.Enums;

namespace AccessControlSystem.Entities
{
    public class AccessRule
    {
        public Role Role { get; set; }

        public int ZoneId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
