using System;
using Win.App.Client.Msg;
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
