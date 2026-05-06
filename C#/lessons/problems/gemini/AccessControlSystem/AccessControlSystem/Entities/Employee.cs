using AccessControlSystem.Enums;

namespace AccessControlSystem.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Role Role { get; set; }
    }
}
