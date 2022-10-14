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
    public class VeController : Controller
    {
        // GET: Ve

        Ve VE = new Ve();
        public ActionResult Index()
        {
            return View(VE.BangVe());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Booking n)
        {
            VE.Them(n);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(VE.LayV(id));
        }
        [HttpPost]

        public ActionResult Edit(Booking n)
        {
            VE.Sua(n);
            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int id)
        {
            VE.Xoa(id);
            return RedirectToAction("Index");

        }
    }
}