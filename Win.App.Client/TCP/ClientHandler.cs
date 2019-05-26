using DotNetty.Transport.Channels;
using System.Diagnostics;
using Win.App.Client.Msg;
using Win.App.Model;
using Win.App.Protobuf.Msg;
using static Win.App.Client.TCP.ClientTools;

namespace Win.App.Client.TCP
{
    public class ClientHandler : SimpleChannelInboundHandler<MsgProto>
    {
        protected override void ChannelRead0(IChannelHandlerContext context, MsgProto msg)
        {
            ClientTools tools = new ClientTools();

            tools.PrintMsg(context, msg, PrintMsgType.RECEIVE);
            switch (msg.TypeProto)
            {
                case MsgTypeProto.Unknown:
                    break;
                case MsgTypeProto.Appinfo:
                    break;
                case MsgTypeProto.Appinfos:
                    ReceiveMsg<AppInfoProto, AppInfo, string>.SaveData(msg.AppInfosProto, "AppInfo");
                    break;
                case MsgTypeProto.Userinfo:
                    break;
                default:
                    break;
            }
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            Debug.WriteLine("connected => " + context.Channel.RemoteAddress);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            Debug.WriteLine("unconnected => " + context.Channel.RemoteAddress);
            context.CloseAsync();
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            context.Flush();
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
