using System;

namespace Chat_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Chat Server";
            Base.Start();

            while (true)
                Console.ReadLine();
        }
    }
}
