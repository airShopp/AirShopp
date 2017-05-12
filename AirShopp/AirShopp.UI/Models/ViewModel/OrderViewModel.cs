using AirShopp.Domain;
using AirShopp.UI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class OrderViewModel 
    {
        public int CurrentTab { get; set; }
        public string searchDeliveryNoteNum { get; set; }
        public PendingPaymentStatusViewModel PendingPaymentStatusViewModel { get; set; }
        public PendingDeliveryStatusViewModel PendingDeliveryStatusViewModel { get; set; }
        public PendingReceivedStatusViewModel PendingReceivedStatusViewModel { get; set; }
        public PendingCommentStatusViewModel PendingCommentStatusViewModel { get; set; }
        public AllStatusViewModel AllStatusViewModel { get; set; }

    }

    public class PendingPaymentStatusViewModel : PageListBaseModel
    {
        public List<Order> PendingPaymentOrder { get; set; }
        public PendingPaymentStatusViewModel()
        {
            PendingPaymentOrder = new List<Order>();
        }
    }
    public class PendingDeliveryStatusViewModel : PageListBaseModel
    {
        public List<Order> PendingDeliveryOrder { get; set; }

        public PendingDeliveryStatusViewModel()
        {
            PendingDeliveryOrder = new List<Order>();
        }
    }
    public class PendingReceivedStatusViewModel : PageListBaseModel
    {
        public List<Order> PendingReceivedOrder { get; set; }
        public PendingReceivedStatusViewModel()
        {
            PendingReceivedOrder = new List<Order>();
        }
    }
    public class PendingCommentStatusViewModel : PageListBaseModel
    {
        public List<Order> PendingComment { get; set; }
        public PendingCommentStatusViewModel()
        {
            PendingComment = new List<Order>();
        }
    }
    public class AllStatusViewModel : PageListBaseModel
    {
        public List<Order> AllOrder { get; set; }
        public AllStatusViewModel()
        {
            AllOrder = new List<Order>();
        }
    }

    public class OrderDataModel
    {
        public long Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } //OBLIGATION TRANSFER DELIVERY FINISHED
        public DateTime DeliveryDate { get; set; }
        public bool IsSpecialOrder { get; set; }
        public string SpecialType { get; set; }
        public long CustomerId { get; set; }
        public string  CustomerName { get; set; }
        public long AddressId { get; set; }
        //public virtual Address Address { get; set; }

        //public virtual ICollection<Return> Returns { get; set; }
        //public virtual ICollection<DeliveryInfo> DeliveryInfos { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}