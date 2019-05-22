using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using Win.App.Model;
using Win.App.Protobuf.Msg;
using Win.App.Server.Database.BLL;

namespace Win.App.Server.TCP
{
    public class ServerTools
    {
        public void SendAppInfos(IChannelHandlerContext context)
        {
            AppInfoBLL appInfoBLL = new AppInfoBLL();
            List<Model.AppInfo> appInfos = appInfoBLL.SelectAllApp();
            if (appInfos == null || appInfos.Count == 0)
            {
                return;
            }
            MsgProto msgProto = new MsgProto();
            foreach (Model.AppInfo appInfo in appInfos)
            {
                AppInfoProto appInfoProto = new AppInfoProto
                {
                    Name = appInfo.Name,
                    Url = appInfo.Url,
                    Img = appInfo.Img,
                    DescribeEN = appInfo.DescribeEN,
                    DescribeCN = appInfo.DescribeCN,
                    DownloadUrl32 = appInfo.DownloadUrl32,
                    DownloadUrl64 = appInfo.DownloadUrl64,
                    Version = appInfo.Version,
                    ReleaseDate = appInfo.ReleaseDate.ToString("yyyy-MM-dd"),
                    Score = appInfo.Score,
                    Type = appInfo.Type,
                    LogoUrl = appInfo.LogoUrl
                };
                msgProto.AppInfosProto.Add(appInfo.Name, appInfoProto);
            }
            msgProto.TypeProto = MsgTypeProto.Appinfos;
            msgProto.SendDateTime = DateTimeNow;
            context.WriteAndFlushAsync(msgProto);
            PrintMsg(context, msgProto, PrintMsgType.SEND);
        }

        public void PrintMsg(IChannelHandlerContext ctx, MsgProto msg, PrintMsgType type)
        {
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine(type);
            Console.WriteLine("\tDateTime: " + DateTimeNow);
            Console.WriteLine("\tAddress: " + ctx.Channel.RemoteAddress);
            Console.WriteLine("\tMsg: " + msg);
            Console.WriteLine("--------------------------------------------\n");
        }

        public string DateTimeNow { get { return DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); } }

        public enum PrintMsgType
        {
            SEND = 0,
            RECEIVE = 1
        }
    }
}
