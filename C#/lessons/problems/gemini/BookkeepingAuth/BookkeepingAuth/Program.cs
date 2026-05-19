using BookkeepingAuth;

Console.WriteLine("Hello, World!");

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Тестовые данные. Меняй их, чтобы проверить разные сценарии:
string inputUser = "Abdullokhon";
string inputPass = "qwerty1234"; // Правильный: "qwerty1234"
bool isUserSuspended = false;     // Если сделать true — выбросит наше исключение

try
{
    Console.WriteLine("--- Попытка входа ---");

    // Вызываем метод и сохраняем результат (true/false)
    bool isSuccess = Login(inputUser, inputPass, isUserSuspended);

    // Обрабатываем обычный бизнес-результат (Паттерн Result / Возврат значения)
    if (isSuccess)
    {
        Console.WriteLine("ДОСТУП РАЗРЕШЕН: Добро пожаловать в Bookkeeping!");
    }
    else
    {
        Console.WriteLine("ДОСТУП ЗАПРЕЩЕН: Неверный пароль.");
    }
}
// Ловим ошибку валидации аргументов (имя параметра покажется автоматически)
catch (ArgumentException ex)
{
    Console.WriteLine($"[ОШИБКА ВАЛИДАЦИИ]: {ex.Message}");
}
// Ловим наше кастомное исключение безопасности
catch (UserSuspendedException ex)
{
    Console.WriteLine($"[БЛОКИРОВКА БЕЗОПАСНОСТИ]: {ex.Message}");
    Console.WriteLine("Рекомендация: Обратитесь в службу поддержки.");
}
// Общая подушка безопасности
catch (Exception ex)
{
    Console.WriteLine($"[НЕПРЕДВИДЕННАЯ ОШИБКА]: {ex.Message}");
}

// Метод для аутентификации пользователя
static bool Login(string username, string password, bool isSuspended)
{
    // Используем try-finally, чтобы гарантировать очистку данных сессии в любом случае
    try
    {
        // Проверка 1: Исключительная ситуация (программист передал пустую строку в метод)
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Имя пользователя не может быть пустым.", nameof(username));
        }

        // Проверка 2: Критическое нарушение безопасности (Кастомное исключение)
        if (isSuspended)
        {
            throw new UserSuspendedException($"Пользователь '{username}' временно заблокирован за подозрительную активность.");
        }

        // Проверка 3: Обычная ошибка пользователя (НЕ используем исключения, возвращаем bool)
        if (password != "qwerty1234")
        {
            return false;
        }

        // Если всё прошло успешно
        return true;
    }
    finally
    {
        // Этот блок сработает ВСЕГДА: 
        // И при return true, и при return false, и при любом throw!
        Console.WriteLine("[LOG]: Очистка конфиденциальных данных сессии.");
    }
}
