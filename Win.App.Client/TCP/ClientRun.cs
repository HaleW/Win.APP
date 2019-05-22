using DotNetty.Common.Internal.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Win.App.Client.Config;

namespace Client.DotNettyClient
{
    public class ClientRun
    {
        public static IChannel ClientChannel { get; private set; }
        public async Task RunAsync()
        {
            InternalLoggerFactory.DefaultFactory.AddProvider(new ConsoleLoggerProvider((s, level) => true, false));

            IEventLoopGroup group = new MultithreadEventLoopGroup();

            X509Certificate2 x509Certificate2 = null;
            if (Config.IsSsl)
            {
                
            }

            try
            {
                Bootstrap bootstrap = new Bootstrap();

                bootstrap
                    .Group(group)
                    .Channel<TcpSocketChannel>()
                    .Option(ChannelOption.SoKeepalive, true)
                    .Option(ChannelOption.TcpNodelay, true)
                    .Handler(new ClientInitializer());
                
                IChannel channel = await bootstrap.ConnectAsync(new IPEndPoint(Config.IP, Config.Port));

                ClientChannel = channel;
                
                Debug.WriteLine("IP => " + Config.IP.ToString() + ", Port => " + Config.Port);
                Console.ReadKey();
                await channel.CloseAsync();
            }
            finally
            {
                await group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
            }
        }
    }
}
