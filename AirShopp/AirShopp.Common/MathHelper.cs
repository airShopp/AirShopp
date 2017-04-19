using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
