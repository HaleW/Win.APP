using System;
using DotNetty.Common.Utilities;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using Win.App.Protobuf.Msg;
using static Win.App.Server.TCP.ServerTools;

namespace Win.App.Server.TCP
{
    public class ServerHandler : SimpleChannelInboundHandler<MsgProto>
    {
        protected override void ChannelRead0(IChannelHandlerContext context, MsgProto msg)
        {
            ServerTools tools = new ServerTools();
            tools.PrintMsg(context, msg, PrintMsgType.RECEIVE);
           
            switch (msg.TypeProto)
            {
                case MsgTypeProto.Unknown:
                    break;
                case MsgTypeProto.Appinfo:
                    break;
                case MsgTypeProto.Appinfos:
                    tools.SendAppInfos(context);
                    break;
                case MsgTypeProto.Userinfo:
                    break;
                default:
                    break;
            }
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            Console.WriteLine(context.Channel.RemoteAddress + " => active");
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            Console.WriteLine(context.Channel.RemoteAddress + " => inactive");
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            context.Flush();
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine(context.Channel.RemoteAddress + " => " + exception.Message);
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
