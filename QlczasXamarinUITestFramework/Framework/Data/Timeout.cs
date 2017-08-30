using System;

namespace QlczasXamarinUITestFramework.Framework.Data
{
    public static class Timeout
    {
        public static TimeSpan None => TimeSpan.FromSeconds(0);
        public static TimeSpan VeryShort => TimeSpan.FromSeconds(3); //Set as Default
        public static TimeSpan Medium => TimeSpan.FromSeconds(7);
        public static TimeSpan Long => TimeSpan.FromSeconds(15);
        public static TimeSpan VeryLong => TimeSpan.FromSeconds(30);
    }
}
