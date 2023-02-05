using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace Server
{
    public class Server
    {
        public TcpListener? SocketOuvinte = null;
        public Server(string hostname, int port) {
            IPAddress localAddress = IPAddress.Parse(hostname);
            try
            {
                SocketOuvinte = new TcpListener(localAddress, port);

                SocketOuvinte.Start();
                loopServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

        public string Features(string commandReceived) {

            switch (commandReceived) {

                case string cmd when cmd.StartsWith("!echo "):
                    return $"{commandReceived.Substring(6).ToUpper()}";

                default:
                    return "[!] Comando inválido";
            }
        }

        public void loopServer() {
            byte[] bytes = new byte[256];
            string data = "";

            while (true)
            {
                Console.Write("Aguardando conexão... ");

                using TcpClient client = SocketOuvinte.AcceptTcpClient();
                Console.WriteLine("Conectei!");

                data = string.Empty;

                NetworkStream stream = client.GetStream();

                int i;


                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {

                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    string rcv = Features(data);
                    byte[] msg = Encoding.UTF8.GetBytes(rcv);
                    stream.Write(msg, 0, msg.Length); 

                }
            }
        }

    }
}
