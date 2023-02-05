using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Client
    {
        public TcpClient? SocketClient { get; set; }

        public void SendMessage() {
            string message;
            byte[] data;
            while (true) {
                message = Console.ReadLine().Trim().ToString() ?? "";
                data = Encoding.UTF8.GetBytes(message);

                NetworkStream stream = SocketClient.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine($"[Client-Server] Enviado: {message}");

                data = new byte[256];
                string responseData = string.Empty;

                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine($"[Server-Client]: {responseData}");
            }
        }
        public Client(string host, int port)
        {
            try
            {
                var st = Console.ReadKey(true);
                SocketClient = new TcpClient(host, port);
                SendMessage();

               
            } catch(Exception ex) { 
                  Console.WriteLine(ex.Message.ToString()); 
                throw;
            }

        }
    }
}
