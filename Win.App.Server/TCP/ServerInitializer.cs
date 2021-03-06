﻿using DotNetty.Codecs.Protobuf;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Win.App.Protobuf.Msg;

namespace Win.App.Server.TCP
{
    public class ServerInitializer : ChannelInitializer<IChannel>
    {
        protected override void InitChannel(IChannel channel)
        {
            IChannelPipeline pipeline = channel.Pipeline;

            //半包处理
            pipeline.AddLast(new ProtobufVarint32FrameDecoder());
            //告诉ProtobufDecoder需要解码的目标是什么
            pipeline.AddLast(new ProtobufDecoder(MsgProto.Parser));
            pipeline.AddLast(new ProtobufVarint32LengthFieldPrepender());
            pipeline.AddLast(new ProtobufEncoder());
            pipeline.AddLast(new LoggingHandler());

            pipeline.AddLast(new ServerHandler());
        }
    }
}
