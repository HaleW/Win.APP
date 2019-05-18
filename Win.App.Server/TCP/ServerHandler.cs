using System;
using DotNetty.Transport.Channels;
using Win.App.Protobuf.Src;

namespace Win.App.Server.TCP
{
    public class ServerHandler : ChannelHandlerAdapter
    {
        public override void ChannelActive(IChannelHandlerContext context)
        {
            Console.WriteLine(context.Channel.RemoteAddress+"active");
            AppInfoProto infoProto = new AppInfoProto();
            infoProto.Name = "active";

            context.WriteAndFlushAsync(infoProto);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            Console.WriteLine(context.Channel.RemoteAddress+"inactive");
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            Console.WriteLine(context.Channel.RemoteAddress + "=>" + message);
            AppInfoProto infoProto = new AppInfoProto();
            infoProto.Name = "receive";
            context.WriteAndFlushAsync(infoProto);
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            context.Flush();
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine(context.Channel.RemoteAddress + "=>" + exception.Message);
        }

        public override void HandlerAdded(IChannelHandlerContext context)
        {
            base.HandlerAdded(context);
        }

        public override void HandlerRemoved(IChannelHandlerContext context)
        {
            base.HandlerRemoved(context);
        }

        public override void UserEventTriggered(IChannelHandlerContext context, object evt)
        {
            base.UserEventTriggered(context, evt);
        }
    }
}
