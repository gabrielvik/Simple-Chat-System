using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Chat_Client
{
    class Networking
    {
        public static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 100;

        public static void ConnectToServer()
        {
            while (!ClientSocket.Connected)
            {
                try
                {
                    ClientSocket.Connect(IPAddress.Loopback, Port);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Connection attempt failed");
                }
            }
            Console.WriteLine("Connected");
        }

        public static void ReceiveResponses()
        {
            try
            {
                var buffer = new byte[2048];
                ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None,    
                    ar => {
                        var client = (Socket)ar.AsyncState;
                        var bytesReceived = client.EndReceive(ar);
                        var trimmedBuffer = new byte[bytesReceived];
                        Array.Copy(buffer, trimmedBuffer, bytesReceived);

                        var msg = Encoding.UTF8.GetString(trimmedBuffer);

                        var splittedMsg = new List<string>(msg.Split('|'));
                        if(splittedMsg.Count < 1)
                        {
                            Console.WriteLine("Got invalid message");
                        }
                        else
                        {
                            string msgName = splittedMsg[0];
                            splittedMsg.RemoveAt(0);

                            if (!NetworkMessages.Messages.ContainsKey(msgName))
                                Console.WriteLine("Received a non existant net msg");
                            else
                                NetworkMessages.Messages[msgName]?.Invoke(splittedMsg);
                        }

                        ReceiveResponses();
                        //callback?.Invoke(Encoding.UTF8.GetString(trimmedBuffer));
                    }, ClientSocket);
            }
            catch (SocketException)
            {
                Console.WriteLine("Lost connection");
            }
        }

        public static void ReceiveMessages()
        {
            ReceiveResponses();
        }
    }
}
