using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ChatCli2
{
    public class User
    {
        public string NickName { get; set; }
        public string IpServer { get; set; }
        public int Port { get; set; }


        public User(string NickName, string IpServer, int Port)
        {
            this.NickName = NickName;
            this.IpServer = IpServer;
            this.Port = Port;
        }

    }
}