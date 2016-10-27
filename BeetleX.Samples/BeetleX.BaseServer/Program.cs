using BeetleX.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleX.BaseServer
{
    public class Program : BeetleX.ServerHandlerBase
    {
        private static IServer server;
        private static List<string> items = new List<string>();
        public static void Main(string[] args)
        {
            NetConfig config = new NetConfig();
            server = ServerFactory.CreateTcpServer<Program>(config);
            server.Open();
            Console.Read();
        }
        public override void Connected(IServer server, ConnectedEventArgs e)
        {
            base.Connected(server, e);
            items.Clear();
        }
        public override void SessionReceive(IServer server, EventArgs.SessionReceiveEventArgs e)
        {
            string value = e.Reader.ReadLine();
            Console.WriteLine(value);
            e.Session.Writer.WriteLine(value);
            e.Session.Writer.Flush();
            base.SessionReceive(server, e);
        }
    }
}
