using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace Chat_Server
{
    class User
    {
        public static List<User> Users = new List<User>();
        public string Name;
        public int ID;

        [JsonIgnore]
        public Socket clientInstance;

        private static int userId = 0;

        public User(Socket client, string name)
        {
            clientInstance = client;
            userId++;
            Name = name;
            ID = userId;
            Users.Add(this);
        }

        public static void SendAllUsers(Socket client)
        {
            foreach(var user in Users)
            {
                var sendData = Encoding.ASCII.GetBytes($"{user.Name}|{user.ID}");

                client.Send(sendData);
            }
        }

        public static List<User> GetAll()
        {
            var users = new List<User>();
            foreach (User user in Users)
                users.Add(user);

            return users;
        }
    }
}
