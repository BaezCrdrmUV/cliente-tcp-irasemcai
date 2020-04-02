using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Esperando conexión...");

            IPAddress address = IPAddress.Parse("127.0.0.1");
            try
            {
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 8080);
                Console.WriteLine("Conectado!");

                while (client.Connected)
                {

                    /**
                     * Cliente envía un mensaje al serverTCP
                     */
                    Console.WriteLine("Escriba un mensaje para el servidor/ bye para desconectarte");
                    string mensaje = Console.ReadLine();
                    
                    var stream = client.GetStream();
                    byte[] paquete = Encoding.UTF8.GetBytes(mensaje);
                    Console.WriteLine("Transmitiendo...");
                    stream.Write(paquete, 0, paquete.Length);



                    /**
                     * Cliente recibe msj del servidor
                     */
                    byte[] paqueteFromServer = new byte[1024];
                    stream.Read(paqueteFromServer);
                    string mensajeFromServer = Encoding.ASCII.GetString(paqueteFromServer);
                    Console.WriteLine(mensajeFromServer);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("1. "+e);
            }catch(SocketException e)
            {
                Console.WriteLine("2. "+e);
            }
            Console.WriteLine("Presiona Enter para continuar");
            Console.Read();
        }
    }
}
