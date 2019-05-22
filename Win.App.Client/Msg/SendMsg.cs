using Client.DotNettyClient;
using DotNetty.Transport.Channels;
using Win.App.Client.TCP;
using Win.App.Protobuf.Msg;

namespace Win.App.Client.Msg
{
    public class SendMsg
    {
        public SendMsg()
        {
            Channel = ClientRun.ClientChannel;
            Tools = new ClientTools();
        }

        private readonly IChannel Channel;

        private readonly ClientTools Tools;

        public void GetAppInfos()
        {
            if (Channel != null && Channel.IsWritable)
            {
                Channel.WriteAndFlushAsync(GetAppInfosMsg);
            }
        }

        private MsgProto GetAppInfosMsg
        {
            get
            {
                MsgProto msgProto = new MsgProto
                {
                    TypeProto = MsgTypeProto.Appinfos,
                    SendDateTime = Tools.DateTimeNow
                };

                return msgProto;
            }
        }
    }
}
