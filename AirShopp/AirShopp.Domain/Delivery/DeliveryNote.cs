using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class DeliveryNote
    {
        public DeliveryNote()
        {

        }

        // 派送单
        public long Id { get; set; }// PK
        public string DeliveryNoteNumber { get; set; }// Serial Number like 3323432518118
        public string BarCodeImgURL { get; set; }// BarCode Image
        public string QRCodeImgURL { get; set; }// QRCode Image
        public string Remarks { get; set; }// Remarks

        public long OrderId { get; set; }// Foreign key ref Order (Id)
        public virtual Order Order { get; set; }
    }
}
