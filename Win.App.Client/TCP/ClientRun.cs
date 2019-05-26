using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Win.App.Protobuf.Msg;
using static Win.App.Client.Config.Config;

namespace Win.App.Client.TCP
{
    public class ClientRun
    {
        public static IChannel ClientChannel;
        public async Task RunAsync()
        {
            IEventLoopGroup group = new MultithreadEventLoopGroup();

            X509Certificate2 x509Certificate2 = null;
            if (IsSsl)
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

                ClientChannel = await bootstrap.ConnectAsync(new IPEndPoint(IP, Port));
               
                Debug.WriteLine("IP => " + IP.ToString() + ", Port => " + Port);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                await ClientChannel.CloseAsync();
                await group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
            }
        }
    }
}
