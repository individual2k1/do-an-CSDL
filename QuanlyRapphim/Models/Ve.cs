using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanlyRapphim.Models
{
    public class Ve
    {
        QLRPCNSEntities VE = new QLRPCNSEntities();
        public IEnumerable<Booking> BangVe()
        {
            return VE.Bookings.ToList();

        }
        public Booking LayV(int id)
        {

            return VE.Bookings.First(m => m.BooId.CompareTo(id) == 0);
        }

        public void Them(Booking n)
        {
            VE.Bookings.Add(n);
            VE.SaveChanges();

        }
        public void Sua(Booking n)
        {
            Booking x = LayV(n.BooId);
            x.Bilmoney = n.Bilmoney;
            x.BooId  = n.BooId;
            x.Quantity = n.Quantity;
            x.CusId = n.CusId;
            x.ShoId = n.ShoId;
            x.DateBooking = n.DateBooking;
            x.Status = n.Status;
            VE.SaveChanges();

        }
        public void Xoa(int id)
        {
            Booking n = LayV(id);
            VE.Bookings.Remove(n);
            VE.SaveChanges();
        }

    }
}