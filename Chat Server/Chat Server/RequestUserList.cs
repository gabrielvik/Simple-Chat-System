using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace Chat_Server
{
    class RequestUserList
    {
        public static void Handle(Socket client, List<string> arguments)
        {
            var users = User.GetAll();

            var json = JsonConvert.SerializeObject(users);

            var sendData = Encoding.ASCII.GetBytes($"ReceiveUserList|{json}");
            client.Send(sendData);
        }
    }
}
