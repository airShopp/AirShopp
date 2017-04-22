using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Common
{
    public class MessageConstants
    {
        public static string USER_NAME_ERROR = "User name is error";
        public static string PASSWORD_ERROR = "Password is error";

        public static string DELIVERYINFO_START_MESSAGE = "您的订单开始处理";
        public static string DELIVERYINFO_PACKAGE_MESSAGE = "卖家发货，[{0}]已收件打包";
        public static string DELIVERYINFO__RECEIVE_MESSAGE = "[{0}]已收入";
        public static string DELIVERYINFO_TRANSFER_MESSAGE = "[{0}]已发出，下一站[{1}]";
        public static string DELIVERYINFO_DELIVERY_MESSAGE = "[{0}]派送员： {1}正在为您派件，电话：{2}";
        public static string DELIVERYINFO_END_MESSAGE = "您已在{0}完成取件，订单派送成功";
    }
}
