using DotNetty.Transport.Channels;
using System;
using System.Diagnostics;
using Win.App.Protobuf.Msg;

namespace Win.App.Client.TCP
{
    public class ClientTools
    {
        public void PrintMsg(IChannelHandlerContext ctx, MsgProto msg, PrintMsgType type)
        {
            Debug.WriteLine("\n--------------------------------------------");
            Debug.WriteLine(type);
            Debug.WriteLine("\tDateTime: " + DateTimeNow);
            Debug.WriteLine("\tAddress: " + ctx.Channel.RemoteAddress);
            Debug.WriteLine("\tMsg: " + msg);
            Debug.WriteLine("--------------------------------------------\n");
        }
        public string DateTimeNow { get { return DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); } }

        public enum PrintMsgType
        {
            SEND = 0,
            RECEIVE = 1
        }
    }
}
