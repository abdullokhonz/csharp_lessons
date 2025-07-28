namespace ad
{
    enum Roles : byte
    {
        Guest,
        User,
        Moderator,
        Admin
    }

    [Flags]
    enum Permissions : byte
    {
        None = 0,           // 0000
        Read = 1 << 0,      // 0001 → 1
        Write = 1 << 1,     // 0010 → 2
        Delete = 1 << 2,    // 0100 → 4
        Execute = 1 << 3,   // 1000 → 8
        Admin = 1 << 4      // 1_0000 → 16
    }

    public class AccessManagementSystem
    {
        List<Roles>? roles { get; set; }
        List<Permissions>? permissions { get; set; }

        public AccessManagementSystem()
        {
            roles = new List<Roles>();
            permissions = new List<Permissions>();
        }

        private void Init()
        {
            roles = Enum.GetValues(typeof(Roles)).Cast<Roles>().ToList();
            permissions = Enum.GetValues(typeof(Permissions)).Cast<Permissions>().ToList();
        }

        Permissions GetPermissionsForRole(Roles role)
        {
            switch (role)
            {
                case Roles.Guest:
                    return Permissions.Read;
                case Roles.User:
                    return Permissions.Read |
                        Permissions.Write;
                case Roles.Moderator:
                    return Permissions.Read |
                        Permissions.Write |
                        Permissions.Delete;
                case Roles.Admin:
                    return Permissions.Read |
                        Permissions.Write |
                        Permissions.Delete |
                        Permissions.Execute |
                        Permissions.Admin;
                default:
                    return Permissions.None;
            }
        }

        bool CanPerformAction(Roles role, Permissions action)
        {
            var rolePerms = GetPermissionsForRole(role);
            return rolePerms.HasFlag(action);
        }

        public void Test()
        {
            byte selectedIndex = 0;

            Init();

            bool selectingRole = true;
            Roles selectedRole = Roles.Guest;
            Permissions selectedPermission = Permissions.Read;

            while (true)
            {
                Console.Clear();

                if (selectingRole)
                    Console.WriteLine("=== Select Role ===");
                else
                    Console.WriteLine("=== Select Action ===");

                var list = selectingRole ? roles?.Cast<object>().ToList() : permissions?.Cast<object>().ToList();

                for (int i = 0; i < list?.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("-> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.WriteLine(list[i]);

                    Console.ResetColor();
                }

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 0)
                            selectedIndex--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (selectedIndex < list?.Count - 1)
                            selectedIndex++;
                        break;

                    case ConsoleKey.Enter:
                        if (selectingRole)
                        {
                            selectedRole = (Roles)list[selectedIndex];
                            selectedIndex = 0;
                            selectingRole = false;
                        }
                        else
                        {
                            selectedPermission = (Permissions)list[selectedIndex];
                            Console.Clear();

                            Console.WriteLine($"Role: {selectedRole}");
                            Console.WriteLine($"Action: {selectedPermission}");

                            Permissions rolePermissions = GetPermissionsForRole(selectedRole);
                            bool allowed = CanPerformAction(selectedRole, selectedPermission);

                            Console.ForegroundColor = allowed ? ConsoleColor.Green : ConsoleColor.Red;
                            Console.WriteLine(allowed
                                ? "  Allowed execute action"
                                : "  Access denied");
                            Console.ResetColor();

                            Console.WriteLine("\nPress any key to start over...");
                            Console.ReadKey();
                            selectedIndex = 0;
                            selectingRole = true;
                        }
                        break;
                }
            }
        }
    }
}
