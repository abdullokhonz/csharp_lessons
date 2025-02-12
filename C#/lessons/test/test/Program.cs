public struct MainClass
{
    static void Pluser<T>(params T?[] parameters)
    {
        string message = "Data type \"{0}\", value \"{1}\".";

        foreach (var parameter in parameters)
            Console.WriteLine(message, parameter?.GetType(), parameter);
    }

    public static void Main() => Pluser<object>(1, true, "hello", 2.5, 4.3f, '!', false, 3.24m, 6.45e23, null, "world");
}
