using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace AirShopp.Common
{
    public class QRCodeHelper
    {
        /// <summary>
        /// Get QRImage
        /// </summary>
        /// <param name="content">Content should be convert to QRCode</param>
        /// <returns>if content is empty, return stirng.Empty, else return imageUrl</returns>
        public static String GetQRImage(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }
            string timeStr = DateTime.Now.ToFileTime().ToString();
            Bitmap bitmap = QRCodeEncoderUtil(content);
            string fileName = HttpRuntime.AppDomainAppPath.ToString() + Constants.IMG_LOCATION + timeStr + Constants.PIC_SUFFIX_JPG;

            bitmap.Save(fileName);//Save bitmap
            string imageUrl = Constants.IMG_LOCATION + timeStr + Constants.PIC_SUFFIX_JPG;

            return imageUrl;
        }

        /// <summary>
        /// Get QRImage content
        /// </summary>
        /// <param name="imageName">QRCode image name</param>
        /// <returns>Content of QRCode</returns>
        public static string GetQRImageContent(string imageName)
        {
            string fileUrl = HttpRuntime.AppDomainAppPath.ToString() + Constants.IMG_LOCATION + imageName;

            Bitmap bitMap = new Bitmap(fileUrl);
            string content = QRCodeDecoderUtil(bitMap);
            return content;
        }

        /// <summary> 
        /// Generate QRCode
        /////// </summary> 
        /// <param name="qrCodeContent">Content should be encode</param> 
        /// <returns>Bitmap of QRCode</returns> 
        private static Bitmap QRCodeEncoderUtil(string qrCodeContent)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeVersion = 0;
            Bitmap img = qrCodeEncoder.Encode(qrCodeContent, Encoding.UTF8);//Use UTF-8 to support chinese
            return img;
        }

        /// <summary> 
        /// analysis QRCode
        /// </summary> 
        /// <param name="bitmap">QRCode Bitmap should be analysis</param> 
        /// <returns>content of QRCode</returns> 
        private static string QRCodeDecoderUtil(Bitmap bitmap)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            string decodedString = decoder.decode(new QRCodeBitmapImage(bitmap), Encoding.UTF8);//Use UTF-8 to support chinese
            return decodedString;
        }
    }
}
