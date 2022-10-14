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
    public class RapchieuController : Controller
    {
        QLRPCNSEntities db = new QLRPCNSEntities();
        Rap RAP = new Rap();
        public ActionResult Index()
        {

            return View(RAP.Bangrap());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cinema n, HttpPostedFileBase uploadhinh)
        {
            RAP.Them(n);
            db.Cinemas.Add(n);

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.Cinemas.ToList().Last().CinId.ToString());
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "P" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/Rapimages"), _FileName);
                uploadhinh.SaveAs(_path);

                Cinema uP = db.Cinemas.FirstOrDefault(x => x.CinId== id);
                uP.Image = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            return View(RAP.LayR(id));
        }
        [HttpPost]

        public ActionResult Edit(Cinema n)
        {
            RAP.Sua(n);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            RAP.Xoa(id);
            return RedirectToAction("Index");

        }
    }
}