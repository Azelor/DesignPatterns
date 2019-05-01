using System;
using System.Text;

namespace GoF.Aids
{
    public static class GetRandom
    {
        private static readonly Random R = new Random();


        public static bool Bool()
        {
            return Int32() % 2 == 0;
        }

        public static char Char(char min = char.MinValue, char max = char.MaxValue)
        {
            return (char)UInt16(min, max);
        }

        public static DateTime DateTime(DateTime? minValue = null, DateTime? maxValue = null)
        {
            var min = minValue ?? System.DateTime.MinValue;
            var max = maxValue ?? System.DateTime.MaxValue;
            var d = new DateTime(Int64(min.Ticks, max.Ticks));
            if (d.Hour == 3) d = d.AddHours(UInt8(4, 22));
            return d;
        }

        public static decimal Decimal(decimal min = decimal.MinValue,
            decimal max = decimal.MaxValue)
        {
            if (min == max) return min;
            try {
                return Convert.ToDecimal(Double(Convert.ToDouble(min), Convert.ToDouble(max)));
            } catch { return min; }
        }

        public static double Double(double min = double.MinValue, double max = double.MaxValue)
        {
            if (min.CompareTo(max) == 0) return min;
            var d = R.NextDouble();
            if (max > 0) return min + d * max - d * min;
            return min - d * min + d * max;
        }

        public static float Float(float min = float.MinValue, float max = float.MaxValue)
        {
            return Convert.ToSingle(Double(min, max));
        }

        public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue)
        {
            return (sbyte)Int32(min, max);
        }

        public static short Int16(short min = short.MinValue, short max = short.MaxValue)
        {
            return (short)Int32(min, max);
        }

        public static int Int32(int min = int.MinValue, int max = int.MaxValue)
        {
            if (min.CompareTo(max) == 0) return min;
            if (min.CompareTo(max) > 0) return R.Next(max, min);
            return R.Next(min, max);
        }

        public static long Int64(long min = long.MinValue, long max = long.MaxValue)
        {
            if (min == max) return min;
            try {
                return Convert.ToInt64(Double(Convert.ToDouble(min), Convert.ToDouble(max)));
            } catch { return min; }
        }

        public static string String(byte minLenght = 5, byte maxLenght = 10)
        {
            var b = new StringBuilder();
            var size = UInt8(minLenght, maxLenght);
            for (var i = 0; i < size; i++) b.Append(Char('a', 'z'));
            return b.ToString();
        }

        public static TimeSpan TimeSpan()
        {
            return new TimeSpan(Int64());
        }

        public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue)
        {
            return (byte)Int32(min, max);
        }

        public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue)
        {
            return (ushort)Int32(min, max);
        }

        public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue)
        {
            return Convert.ToUInt32(Double(min, max));
        }

        public static ulong UInt64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue)
        {
            if (min == max) return min;
            try {
                return Convert.ToUInt64(Double(Convert.ToDouble(min), Convert.ToDouble(max)));
            } catch { return min; }
        }

    }
}
