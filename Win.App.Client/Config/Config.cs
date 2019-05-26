using System.Net;

namespace Win.App.Client.Config
{
    public static class Config
    {
        //static Config()
        //{
        //    IsSsl = true;
        //    IP = IPAddress.Parse("127.0.0.1");
        //    Port = 8007;
        //    IsLibuv = true;
        //}

        public static bool IsSsl { get; } = true;
        public static IPAddress IP { get; } = IPAddress.Parse("127.0.0.1");
        public static int Port { get; } = 8007;
        public static bool IsLibuv { get; } = true;
    }
}
