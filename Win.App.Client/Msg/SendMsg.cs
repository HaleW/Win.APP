using DotNetty.Transport.Channels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Win.App.Client.TCP;
using Win.App.Protobuf.Msg;

namespace Win.App.Client.Msg
{
    public static class SendMsg
    {
        public static void GetAppInfos()
        {
            IChannel Channel = ClientRun.ClientChannel;
            if (Channel != null && Channel.IsWritable)
            {
                try
                {
                    Channel.WriteAndFlushAsync(GetAppInfosMsg);
                }
                catch (Exception e)
                {
                    Debug.Fail(e.Message);
                }
            }
        }

        private static MsgProto GetAppInfosMsg
        {
            get
            {
                ClientTools Tools = new ClientTools();
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
