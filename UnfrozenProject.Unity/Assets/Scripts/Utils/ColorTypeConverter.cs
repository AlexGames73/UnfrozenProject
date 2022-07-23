using System;
using System.Globalization;
using UnityEngine;

namespace Utils
{
    public static class ColorTypeConverter
    {
        public static int ToArgb(Color c)
        {
            var argb = $"{ToByte(c.a):X2}{ToByte(c.r):X2}{ToByte(c.g):X2}{ToByte(c.b):X2}";
            return int.Parse(argb, NumberStyles.HexNumber);
        }

        public static Color FromArgb(int argb)
        {
            var bgra = BitConverter.GetBytes(argb);
            return new Color32(bgra[2], bgra[1], bgra[0], bgra[3]);
        }
 
        private static byte ToByte(float f)
        {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }
    }
}
