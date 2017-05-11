using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class DeliveryNoteRepository : IDeliveryNoteRepository
    {
        private AirShoppContext _context = new AirShoppContext();

        public void AddDeliveryNote(DeliveryNote deliveryNote)
        {
            _context.DeliveryNote.Add(deliveryNote);
            _context.SaveChanges();
        }

        public List<DeliveryNote> GetDeliveryNotes()
        {
            return _context.DeliveryNote.ToList();
        }
    }
}
