using OCP.Problem.Interfaces;

namespace OCP.Problem.Classes
{
    public class EmailSender : ISendMessage
    {
        public string SendMessage(string type, string message)
        {
            return $"Sending {type}: " + message;
        }
    }
}
