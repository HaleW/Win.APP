using System;

namespace Win.App.UWP.Tools
{
    public class TimeTools
    {
        public static long CurrentTimeMillis()
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
            return (long)diff.TotalMilliseconds;
        }

        public static int TimeDiffOfSeconds(DateTime dateTime)
        {
            DateTime now = DateTime.Now;
          
            TimeSpan diff = now.Subtract(dateTime);

            return diff.Seconds;
        } 
    }
}
