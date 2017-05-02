using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Common
{
    public class DateTimeHelper
    {
        public static string GetDateTime(DateTime dateTime)
        {
            return (dateTime.ToShortDateString() + Constants.TEXT_SPACE + dateTime.ToShortTimeString());
        }

        public static string GetDate(DateTime dateTime)
        {
            return dateTime.ToShortDateString();
        }
    }
}
