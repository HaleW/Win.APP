using DotNetty.Codecs.Protobuf;
using DotNetty.Transport.Channels;
using Win.App.Protobuf.Src;

namespace Win.App.Server.TCP
{
    public class ServerInitializer : ChannelInitializer<IChannel>
    {
        protected override void InitChannel(IChannel channel)
        {
            IChannelPipeline pipeline = channel.Pipeline;

            //告诉ProtobufDecoder需要解码的目标是什么
            //pipeline.AddLast(new ProtobufDecoder(UserInfoProto.Parser));
            pipeline.AddLast(new ProtobufDecoder(AppInfoProto.Parser));
            pipeline.AddLast(new ProtobufEncoder());
            //半包处理
            pipeline.AddLast(new ProtobufVarint32FrameDecoder());
            pipeline.AddLast(new ProtobufVarint32LengthFieldPrepender());

            pipeline.AddLast(new ServerHandler());
        }
    }
}
