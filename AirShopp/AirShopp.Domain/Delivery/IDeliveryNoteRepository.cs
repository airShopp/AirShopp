using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IDeliveryNoteRepository
    {
        void AddDeliveryNote(DeliveryNote deliveryNote);
        List<DeliveryNote> GetDeliveryNotes();
    }
}
