using OCP.Problem.Interfaces;

namespace OCP.Problem.Classes
{
    public class MessageSender
    {
        private readonly ISendMessage _sendMessage;

        public MessageSender(ISendMessage sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public string Send(string type, string message)
        {
            return _sendMessage.SendMessage(type, message);
        }
    }
}
