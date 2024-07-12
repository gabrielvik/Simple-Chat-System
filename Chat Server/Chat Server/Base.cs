using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Chat_Server
{
    class Base
    {
        public static Dictionary<string, Action> NetworkCallbacks = new Dictionary<string, Action>();
        private static byte[] Buffer = new byte[1024];
        private static List<Socket> Clients = new List<Socket>();
        private static Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        public static void Start()
        {
            Console.WriteLine("Starting...");
            ServerSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            ServerSocket.Listen(5);
            ServerSocket.BeginAccept(new AsyncCallback(CallbackAccept), null);
            Console.WriteLine("Started");
        }
    
        private static void CallbackAccept(IAsyncResult result)
        {
            Socket socket = ServerSocket.EndAccept(result);
            Console.WriteLine("Client connected");
            Clients.Add(socket);

            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(CallbackReceive), socket);
            ServerSocket.BeginAccept(new AsyncCallback(CallbackAccept), null);
        }

        private static void CallbackReceive(IAsyncResult result)
        {
            Socket socket = (Socket)result.AsyncState;
            int received;

            try
            {
                received = socket.EndReceive(result);
            }
            catch (SocketException)
            {
                DisconnectClient(socket);
                return;
            }
            byte[] buffer = new byte[received];
            Array.Copy(Buffer, buffer, received);

            HandleMessage(socket, Encoding.ASCII.GetString(buffer));

            try
            {
                socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(CallbackReceive), socket);
            }
            catch (SocketException)
            {
                DisconnectClient(socket);
            }
        }

        private static void HandleMessage(Socket client, string msg)
        {
            List<string> splittedMsg = new List<string>(msg.Split('|'));

            if (splittedMsg.Count < 1)
            {
                Console.WriteLine("Got invalid msg");
                return;
            }

            string msgName = splittedMsg[0];

            Type responseClass = Type.GetType("Chat_Server." + msgName);
            if (responseClass == null)
            {
                Console.WriteLine("Tried to handle a net message that doesn't exist");
                return;
            }

            MethodInfo method = responseClass.GetMethod("Handle", BindingFlags.Static | BindingFlags.Public);
            
            splittedMsg.RemoveAt(0);

            object[] paramObj = new object[splittedMsg.Count];
            for(int i = 0; i < splittedMsg.Count; i++)
                paramObj[i] = splittedMsg[i];

            method.Invoke(responseClass, new object[] { client, splittedMsg });
        }

        private static void DisconnectClient(Socket client)
        {
            client.Close();
            Clients.Remove(client);
            var disconnectedUser = User.Users.FirstOrDefault(user => user.clientInstance == client);

            foreach (var user in User.Users)
            {
                if (user.ID == disconnectedUser.ID)
                    continue;

                byte[] sendData = Encoding.ASCII.GetBytes($"ClientDisconnected|{disconnectedUser.ID}");
                user.clientInstance.Send(sendData);
            }

            User.Users.RemoveAll(user => user.ID == disconnectedUser.ID);

            Console.WriteLine("Client disconnected");
        }
    }
}