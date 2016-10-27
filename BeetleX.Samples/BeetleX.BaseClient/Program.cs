using BeetleX.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleX.BaseClient
{
    public class Program
    {

        public static void Main(string[] args)
        {

            BeetleX.Clients.IClient client = ServerFactory.CreateTcpClient("127.0.0.1", 9090);
            client.Receive = (c, e) =>
            {
                lock (e.SyncObject)
                {

                    Console.WriteLine(e.ReadLine());
                }

            };
            client.Connect();
            client.Writer.WriteLine(DateTime.Now.ToString());
            client.Writer.Flush();

            Console.Read();
        }
    }
}
