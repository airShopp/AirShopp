using AirShopp.UI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class DeliveryNoteListViewModel: PageListBaseModel
    {
        public List<DeliveryNoteDataModel> DelvieryNoteDataModelList { get; set; }
        public string searchDeliveryNoteNum { get; set; }
    }

    public class DeliveryNoteDataModel
    {
        public long Id { get; set; }
        public string DeliveryNoteNumber { get; set; }
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverAddress { get; set; }
        public string QRCodeImgSrc { get; set; }
    }
}