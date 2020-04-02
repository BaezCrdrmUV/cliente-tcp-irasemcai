using System;
using System.Net.Sockets;

namespace SocketCom
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TCPServer server = new TCPServer("127.0.0.1", 8080, true);
            try
            {
                server.Listen();
            }catch(SocketException e)
            {
                Console.WriteLine("1. " + e);
            }
            Console.WriteLine("Presiona Enter para continuar");
            Console.Read();
           
        }
    }
}
