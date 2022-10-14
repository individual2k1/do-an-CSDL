using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using QuanlyRapphim.Models;

namespace QuanlyRapphim.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ADMIN()
        {
            int AdmId = int.Parse(Session["AdmId"].ToString());
            QLRPCNSEntities db = new QLRPCNSEntities();
            sp_Admin_GetById_Result AD = db.sp_Admin_GetById(AdmId).FirstOrDefault();

            return View(AD);


        }
        [HttpGet]
        public ActionResult DangkyAD()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangkyAD(Admin TKAD)
        {
            QLRPCNSEntities db = new QLRPCNSEntities();
            sp_Admin_GetById_Result AD = new sp_Admin_GetById_Result();
            AD.AdmId = TKAD.AdmId;
            AD.FullName = TKAD.FullName;
            AD.Username = TKAD.Username;
            AD.Pass = TKAD.Pass;
            db.Admins.Add(TKAD);
            db.SaveChanges();
            return RedirectToAction("DangNhapAD");

        }


        [HttpPost]
        public ActionResult DangNhapAD(Admin TKAD)
        {
            QLRPCNSEntities db = new QLRPCNSEntities();
            int id = TKAD.AdmId;
            string name = TKAD.Username;
            Admin AD = db.Admins.Where(i => (i.Username == name) && (i.Pass == TKAD.Pass)).FirstOrDefault();

            if (AD != null)
            {

                Session["TrangThai"] = "1";
                Session["AdmId"] = AD.AdmId.ToString();       //Da luu trong session
                Session["Username"] = AD.Username.ToString();
                Session["Pass"] = AD.Pass.ToString();

                Session["Fullname"] = AD.FullName;
                Session["Email"] = AD.Email;
                Session["Phone"] = AD.Phone;


                return RedirectToAction("ADMIN");

            }
            return RedirectToAction("DangNhap");
        }

            public ActionResult DangXuat()
            {
                Session.Clear();
                return RedirectToAction("index", "home");

            }

        [HttpGet]
        public ActionResult SuaThongtinAD()
        {
            int AdmId = int.Parse(Session["AdmId"].ToString());
            QLRPCNSEntities DB = new QLRPCNSEntities();
            sp_Admin_GetById_Result AD = DB.sp_Admin_GetById(AdmId).FirstOrDefault();

            return View(AD);


        }

        public ActionResult SuaThongtinAD(Admin a)
        {
            a.AdmId = int.Parse(Session["AdmId"].ToString());
            QLRPCNSEntities DB = new QLRPCNSEntities();
            Admin AD = DB.Admins.FirstOrDefault(c => c.AdmId == a.AdmId);
            //sp_Customer_GetById_Result KH = DB.sp_Customer_GetById(a.CusId).FirstOrDefault();
            AD.FullName = a.FullName;
            AD.Phone = a.Phone;
            AD.Email = a.Email;
            Session["Fullname"] = AD.FullName;
            Session["Email"] = AD.Email;
            Session["Phone"] = AD.Phone;
            //DB.sp_Customer_Update(KH.CusId, KH.Username, KH.CreditCard, KH.FullName, KH.Bod, KH.Address, KH.Phone, KH.Email, KH.Avata, KH.Status);
            DB.SaveChanges();
            //return RedirectToAction("ThongtinKH",new { id = a.CusId }); //Khong can truyen Cusid vi action nay no se lay cusid tu session
            return RedirectToAction("ADMIN");

        }



    }





}
