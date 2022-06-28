using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ChatCli2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Informe seu NickName: ");
            string nickName = Console.ReadLine();
            Console.Write("Informe o IP do Servidor: ");
            string ipServer = Console.ReadLine();
            Console.Write("Informe a Porta do Servidor: ");
            int port = int.Parse(Console.ReadLine());

            IPAddress ip = IPAddress.Parse(ipServer);

            TcpClient client = new TcpClient();
            client.Connect(ip, port);


            Socket client2 = new Socket(AddressFamily.InterNetwork,  SocketType.Stream, ProtocolType.Tcp);
            client2.Connect(ipServer);

            Console.WriteLine("client connected!!");
            NetworkStream ns = client.GetStream();

            byte[] dUser = Encoding.ASCII.GetBytes(nickName);
            byte[] bufffer = dUser;
            ns.Write(bufffer, 0, bufffer.Length);

            string fileName = "D:\\programas\\dotnetapp\\ChatCli2\\teste.txt";

            // Send file fileName to remote device
            Console.WriteLine("Sending {0} to the host.", fileName);
            client2.SendFile(fileName);


            string s;
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Escape)
            {

                byte[] receivedBytes = new byte[1024];
                int byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);
                byte[] formated = new byte[byte_count];
                //handle  the null characteres in the byte array
                Array.Copy(receivedBytes, formated, byte_count);
                string data = Encoding.ASCII.GetString(formated);
                Console.WriteLine(data);


                s = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                ns.Write(buffer, 0, buffer.Length);


            }
            ns.Close();
            client.Close();
            Console.WriteLine("disconnect from server!!");
            Console.ReadKey();
        }
    }
}