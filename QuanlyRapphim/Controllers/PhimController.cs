using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using QuanlyRapphim.Models;

namespace QuanlyRapphim.Controllers
{
    public class PhimController : Controller
    {
        QLRPCNSEntities db = new QLRPCNSEntities();
        phim PHIM = new phim();
        public ActionResult Index()
            {

                return View(PHIM.Bangphim());
            }
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film n, HttpPostedFileBase uploadhinh)
        {
            PHIM.Them(n);
            db.Films.Add(n);
            
            if (uploadhinh != null && uploadhinh.ContentLength>0)
            {
                int id =int.Parse(db.Films.ToList().Last().FilId.ToString());
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "P" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/images"), _FileName);
                uploadhinh.SaveAs(_path);

                Film uP = db.Films.FirstOrDefault(x => x.FilId == id);
                uP.Picture = _FileName;
                db.SaveChanges();
            }    
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            
            return View(PHIM.LayP(id));
        }
         [HttpPost]  

        public ActionResult Edit(Film n)
        {
            PHIM.Sua(n);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            PHIM.Xoa(id);
            return RedirectToAction("Index");

        }


    }
}