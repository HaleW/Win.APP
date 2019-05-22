using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Win.App.Client.Config
{
    public static class Config
    {
        static Config()
        {
            IsSsl = true;
            IP = IPAddress.Parse("127.0.0.1");
            Port = 8007;
            IsLibuv = true;
        }

        public static bool IsSsl { get; }
        public static IPAddress IP { get; }
        public static int Port { get; }
        public static bool IsLibuv { get; }
    }
}
