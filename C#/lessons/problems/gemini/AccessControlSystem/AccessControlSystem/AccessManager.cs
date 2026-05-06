using AccessControlSystem.Entities;
using AccessControlSystem.Enums;

namespace AccessControlSystem
{
    public class AccessManager
    {
        private readonly List<Employee> _employees;

        // Быстрый поиск: Роль -> (Зона -> Список правил времени)
        private readonly Dictionary<Role, Dictionary<int, List<AccessRule>>> _rules;

        public AccessManager(List<Employee> employees, List<AccessRule> rules)
        {
            _employees = employees;
            _rules = new Dictionary<Role, Dictionary<int, List<AccessRule>>>();

            // Группируем правила для мгновенного поиска (Pre-processing)
            foreach (var rule in rules)
            {
                if (!_rules.ContainsKey(rule.Role))
                    _rules[rule.Role] = new Dictionary<int, List<AccessRule>>();

                if (!_rules[rule.Role].ContainsKey(rule.ZoneId))
                    _rules[rule.Role][rule.ZoneId] = new List<AccessRule>();

                _rules[rule.Role][rule.ZoneId].Add(rule);
            }
        }

        public bool CanAccess(int employeeId, int zoneId, DateTime currentTime)
        {
            // Ищем сотрудника
            var emp = _employees.FirstOrDefault(e => e.Id == employeeId);
            if (emp == null) return false;

            // Правило "Админ может всё"
            if (emp.Role == Role.Admin) return true;

            // Быстрый поиск правил для роли и зоны
            if (!_rules.TryGetValue(emp.Role, out var zoneRules) ||
                !zoneRules.TryGetValue(zoneId, out var timeIntervals))
            {
                return false; // Правил нет — доступ закрыт
            }

            // Проверяем время (учитываем только часы и минуты)
            TimeSpan now = currentTime.TimeOfDay;
            return timeIntervals.Any(rule => now >= rule.StartTime && now <= rule.EndTime);
        }
    }
}
