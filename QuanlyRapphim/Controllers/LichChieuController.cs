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
    public class LichChieuController : Controller
    {
        // GET: LichChieu
        
        Lichchieu LICH = new Lichchieu();
        public ActionResult Index()
        {

            return View(LICH.BangChieu());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ShowTime n)
        {
            LICH.Them(n);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(LICH.LayL(id));
        }
        [HttpPost]

        public ActionResult Edit(ShowTime n)
        {
            LICH.Sua(n);
            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int id)
        {
            LICH.Xoa(id);
            return RedirectToAction("Index");

        }
    }
}