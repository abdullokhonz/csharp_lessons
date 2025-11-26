using OCP.Problem.Interfaces;

namespace OCP.Problem.Classes
{
    public class SMSSender : ISendMessage
    {
        public string SendMessage(string type, string message)
        {
            return $"Sending {type}: " + message;
        }
    }
}
