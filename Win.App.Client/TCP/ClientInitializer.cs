using DotNetty.Codecs.Protobuf;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Channels;
using Win.App.Protobuf.Msg;

namespace Client.DotNettyClient
{
    public class ClientInitializer : ChannelInitializer<IChannel>
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

           // pipeline.AddLast(new DelimiterBasedFrameDecoder(65535, );
            //maxFramePayloadLength
            pipeline.AddLast(new ClientHandler());
        }
    }
}
