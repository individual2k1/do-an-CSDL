using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QuanlyRapphim.Models;

namespace QuanlyRapphim.Models
{
    public class Rap
    {
        QLRPCNSEntities RAP = new QLRPCNSEntities();
        public IEnumerable<Cinema> Bangrap()
        {
            return RAP.Cinemas.ToList();

        }
        public Cinema LayR(string id)
        {
            // QLRPCNSEntities DB = new QLRPCNSEntities();
            //return PHIM.Films.First(m => m.NameF.CompareTo(id) == 0);
            int id_convert = int.Parse(id);
            return RAP.Cinemas.First(m => m.CinId == id_convert);
           
        }

        public void Them(Cinema n)
        {
            RAP.Cinemas.Add(n);
            RAP.SaveChanges();

        }
        public void Sua(Cinema n)
        {
            Cinema x = LayR(n.NameCi);
            x.Address = n.Address;
            x.Phone = n.Phone;
            x.Seats = n.Seats;
            x.Image = n.Image;
            x.Status = n.Status;
            RAP.SaveChanges();

        }
        public void Xoa(string id)
        {
            Cinema n = LayR(id);
            RAP.Cinemas.Remove(n);
            RAP.SaveChanges();
        }
    }
}