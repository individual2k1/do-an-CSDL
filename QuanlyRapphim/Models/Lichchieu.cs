using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using QuanlyRapphim.Models;

namespace QuanlyRapphim.Models
{
    public class Lichchieu
    {

        
        QLRPCNSEntities LICH = new QLRPCNSEntities();
        public IEnumerable<ShowTime> BangChieu()
        {
            return LICH.ShowTimes.ToList();

        }
        public ShowTime LayL(int id)
        {

            return LICH.ShowTimes.First(m => m.ShoId.CompareTo(id) == 0);
        }

        public void Them(ShowTime n)
        {
            LICH.ShowTimes.Add(n);
            LICH.SaveChanges();

        }
        public void Sua(ShowTime n)
        {
            ShowTime x = LayL(n.ShoId);
            x.ShowTime1 = n.ShowTime1;
            x.Time = n.Time;
            x.View = n.View;
            x.Price = n.Price;
            x.Status = n.Status;
            x.FilId = n.FilId;
            x.CinId = n.CinId;
            LICH.SaveChanges();

        }
        public void Xoa(int id)
        {
            ShowTime n = LayL(id);
            LICH.ShowTimes.Remove(n);
            LICH.SaveChanges();
        }




    }
}
