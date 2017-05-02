using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Common
{
    public class Constants
    {
        // Common
        public const char TEXT_SPACE = ' ';
        public const char VIRGULE = '/';

        // QRCode
        public const string PIC_SUFFIX_JPG = ".jpg";
        public const string IMG_LOCATION = "Content\\Images\\QRImages\\";

        // BMap
        public const string BMAP_AK = "BZpwjUXFrAlT6g87xFxY4c3Cf82zen93";
        public const string BMAP_BASE_URL = "http://api.map.baidu.com/routematrix/v2/driving?";
        public const string BMAP_OUTPUT_TYPE = "output=json";

        // DeliveryInfo
        public const string START_POINT_NAME = "江苏昆山物流转运中心";
        public const string START_POINT_ADDRESS = "江苏省苏州市昆山市人民路3号";
        public const double START_POINT_LONGITUDE = 120.964369;
        public const double START_POINT_LATITUDE = 31.372474;

        // User
        public const string USER_NAME = "UserName";
        public const string PASSWORD = "Password";
        public const string SESSION_USER = "CUSTOMER";
        public const string IP = "IP";
        public const string TIME = "TIME";
    }
}
