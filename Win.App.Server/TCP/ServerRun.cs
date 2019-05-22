using DotNetty.Common.Internal.Logging;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Libuv;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Win.App.Server.Config;

namespace Win.App.Server.TCP
{
    public class ServerRun
    {
        public async Task RunAsync()
        {
            //InternalLoggerFactory.DefaultFactory.AddProvider(new ConsoleLoggerProvider((s, level) => true, false));

            IEventLoopGroup bossGroup;
            IEventLoopGroup workerGroup;

            if (DotNettyConfig.UseLibuv)
            {
                var dispatcher = new DispatcherEventLoopGroup();
                bossGroup = dispatcher;
                workerGroup = new WorkerEventLoopGroup(dispatcher);
            }
            else
            {
                bossGroup = new MultithreadEventLoopGroup();
                workerGroup = new MultithreadEventLoopGroup();
            }
            //TODO
            //X509Certificate2 x509Certificate2 = null;
            if (DotNettyConfig.IsSsl)
            {
                //x509Certificate2= new X509Certificate2()
            }

            try
            {
                ServerBootstrap bootstrap = new ServerBootstrap();
                bootstrap.Group(bossGroup, workerGroup);

                if (DotNettyConfig.UseLibuv)
                {
                    bootstrap.Channel<TcpServerChannel>();
                }
                else
                {
                    bootstrap.Channel<TcpServerSocketChannel>();
                }

                bootstrap
                    .Option(ChannelOption.SoBacklog, 1024)
                    .Handler(new LoggingHandler())
                    .ChildOption(ChannelOption.SoKeepalive, true)
                    .ChildHandler(new ServerInitializer());

                Console.WriteLine("DotNetty Starting...");

                IChannel boundChannel = await bootstrap.BindAsync(DotNettyConfig.Port);


                Console.WriteLine("DotNetty Started，Port:" + DotNettyConfig.Port);
                Console.ReadKey();
                await boundChannel.CloseAsync();
            }
            finally
            {
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));

                Console.WriteLine("DotNetty Shutdown");
            }
        }
    }
}
