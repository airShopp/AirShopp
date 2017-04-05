using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Common
{
    public class BaseException : Exception
    {
        public string _message;
        public BaseException(string message) : base(message)
        {
            _message = message;
        }
    }
}
