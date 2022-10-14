using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QuanlyRapphim.Models;
using System.ComponentModel;

namespace QuanlyRapphim.Models
{
    
    public class phim
    {

        
        QLRPCNSEntities PHIM = new QLRPCNSEntities();
        public IEnumerable<Film> Bangphim()
        {

            return PHIM.Films.ToList();
            
        }
        public Film LayP(string id)
        {
            //QLRPCNSEntities DB = new QLRPCNSEntities();
            //return PHIM.Films.First(m => m.NameF.CompareTo(id) == 0);
            int id_convert = int.Parse(id);
            return PHIM.Films.First(m => m.FilId==id_convert);
        }
    
        public void Them(Film n)
        {
            PHIM.Films.Add(n);
            PHIM.SaveChanges();

        }
        public void Sua(Film n)
        {
            Film x = LayP(n.NameF);
            x.Director = n.Director;
            x.Actor = n.Actor;
            x.Duration = n.Duration;
            x.TypId = n.TypId;
            x.CouId = n.CouId;
            PHIM.SaveChanges();

        }
        public void Xoa(string id)
        {
            Film n = LayP(id);
            PHIM.Films.Remove(n);
            PHIM.SaveChanges();
        }

        
        
       
    }
}