using System;
using System.Collections.Generic;

namespace Chat_Client
{
    class NetworkMessages
    {
        public static Dictionary<string, Action<List<string>>> Messages = new Dictionary<string, Action<List<string>>>();

        public static void RetreiveMessage(string msg, Action<List<string>> callback)
        {
            Messages[msg] = callback;
        }
    }
}
