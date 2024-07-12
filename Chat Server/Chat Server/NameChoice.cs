using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chat_Server
{
    static class NameChoice
    {
        public static void Handle(Socket client, List<string> arguments)
        {
            var name = arguments[0];

            if (name.Length < 3 || name.Length > 12)
                return;

            User newUser = new User(client, name);

            string userJSON = JsonConvert.SerializeObject(newUser);
            
            byte[] sendData = Encoding.ASCII.GetBytes($"NameChoiceSuccess|{userJSON}");
            client.Send(sendData);

            foreach(var user in User.Users)
            {
                if (user.ID == newUser.ID)
                    continue;

                sendData = Encoding.ASCII.GetBytes($"ClientConnected|{userJSON}");
                user.clientInstance.Send(sendData);
            }
        }
    }
}