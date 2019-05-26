using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Win.App.Client.Msg;
using Win.App.Client.SQLite;
using Win.App.Model;
using Win.App.Protobuf.Msg;
using Win.App.Server.TCP;

namespace Win.App.Server
{
    public class Program
    {
        private static void Main(string[] args)
        {
            new ServerRun().RunAsync().Wait();
        }
    }
}
