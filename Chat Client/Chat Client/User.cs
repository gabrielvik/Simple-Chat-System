using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Chat_Client
{
    public class User
    {
        public static User ClientUser;
        public static Dictionary<int, List<Message>> Messages = new Dictionary<int, List<Message>>();

        public static List<User> Users = new List<User>();
        public string Name;
        public int ID;

        public static void RequestUserList()
        {
            Networking.ClientSocket.Send(Encoding.UTF8.GetBytes("RequestUserList"));

            //Networking.ReceiveResponse(delegate (string msg)
            //{
            //    Console.WriteLine(msg);
            //    Users = JsonConvert.DeserializeObject<List<User>>(msg);
            //    Main.RebuildUsersPanel();
            //});
        }

        public static User GetById(int id)
        {
            return Users.FirstOrDefault(u => u.ID == id);
        }

        public static void ListenForConnectionChanges()
        {
            NetworkMessages.RetreiveMessage("ClientConnected", delegate (List<string> args)
            {
                var user = args[0];
                var userObj = JsonConvert.DeserializeObject<User>(user);
                Users.Add(userObj);

                Main.RebuildUsersPanel();
            });

            NetworkMessages.RetreiveMessage("ClientDisconnected", delegate (List<string> args)
            {
                var disconnectedUser = int.Parse(args[0]);

                Users.RemoveAll(user => user.ID == disconnectedUser);
                Main.RebuildUsersPanel();

                if (Main.SelectedUserID == disconnectedUser)
                {
                    Main.Instance.messagesBack.Invoke(new Action(() =>
                    {
                        Main.Instance.messagesBack.Controls.Clear();
                        Main.SelectedUserID = -1;
                        Main.Instance.choosenUserText.Text = "No user selected";
                    }));
                }
            });
        }

        public static void ListenForUserList()
        {
            NetworkMessages.RetreiveMessage("ReceiveUserList", delegate (List<string> args)
            {
                var userList = args[0];

                Users = JsonConvert.DeserializeObject<List<User>>(userList);
                Main.RebuildUsersPanel();
            });
        }
    }
}
