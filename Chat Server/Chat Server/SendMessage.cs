using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Server
{
    static class SendMessage
    {
        public static void Handle(Socket client, List<string> arguments)
        {
            var message = arguments[1];

            if (message.Length < 1 || message.Length > 255) 
                return;
            else if (message.Count(msg => msg == '\n') == message.Length)
                return;
            else if (message.Count(msg => msg == '\n') > 10)
                return;

            int userId = int.Parse(arguments[0]);

            User msgSender = User.Users.FirstOrDefault(u => u.clientInstance == client);
            User msgReceiver = User.Users.FirstOrDefault(u => u.ID == userId);

            if (msgReceiver != null)
                msgReceiver.clientInstance.Send(Encoding.ASCII.GetBytes($"ReceiveMessage|{msgSender.ID}|{message}"));
        }
    }
}