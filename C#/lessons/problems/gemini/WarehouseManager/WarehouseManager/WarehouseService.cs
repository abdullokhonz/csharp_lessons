namespace WarehouseManager
{
    public class WarehouseService
    {
        public void ProcessInventory(List<IItem> items, int[] xorIds)
        {
            Console.WriteLine("--- Отчет по инвентаризации ---");

            // Dictionary: Считаем дубликаты
            var counts = new Dictionary<int, int>();
            foreach (var item in items)
            {
                if (counts.ContainsKey(item.Id)) counts[item.Id]++;
                else counts[item.Id] = 1;
            }

            foreach (var pair in counts)
                Console.WriteLine($"Товар ID {pair.Key}: {pair.Value} шт.");

            // XOR: Поиск одинокого ID
            int lostId = 0;
            foreach (int id in xorIds) lostId ^= id;
            Console.WriteLine($"\nПотерянный ID (найден через XOR): {lostId}");
        }

        public void SaveReport(List<IItem> items, string filePath)
        {
            try
            {
                // Используем LINQ для получения уникальных имен
                var uniqueNames = items.Select(i => i.Name).Distinct();
                File.WriteAllLines(filePath, uniqueNames);
                Console.WriteLine($"\nОтчет успешно сохранен в: {Path.GetFullPath(filePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи файла: {ex.Message}");
            }
        }
    }
}
