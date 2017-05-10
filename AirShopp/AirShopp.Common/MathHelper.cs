using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Security;

namespace AirShopp.Common
{
    public class MathHelper
    {
        public static double GetDistance(double startPointX, double startPointY, double endPointX, double endPointY)
        {
            double x = System.Math.Abs(endPointX - startPointX);
            double y = System.Math.Abs(endPointY - startPointY);
            return Math.Sqrt(x * x + y * y);
        }

        public static string MD5(string source)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(source, "MD5");
        }

        public static string PadLeft(int length, int num)
        {
            int temp = num.ToString().Length;
            StringBuilder sb = new StringBuilder(num.ToString());
            for (int i = 0; i < length - temp; i++)
            {
                sb.Insert(0, '0');
            }

            return sb.ToString();
        }

        public static string ConvertToChinese(double x)
        {
            string s = x.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            return Regex.Replace(d, ".", m => "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[m.Value[0] - '-'].ToString());
        }
    }
}
