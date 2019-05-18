using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win.App.UWP.Tools
{
    public class CurrentTime
    {
        public static long CurrentTimeMillis()
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
            return (long)diff.TotalMilliseconds;
        }
    }
}
