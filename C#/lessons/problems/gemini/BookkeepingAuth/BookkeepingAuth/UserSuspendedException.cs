namespace BookkeepingAuth
{
    public class UserSuspendedException : Exception
    {
        public UserSuspendedException() { }

        public UserSuspendedException(string message) : base(message) { }

        public UserSuspendedException(string message, Exception inner) : base(message, inner) { }
    }
}
