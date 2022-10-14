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
    public class KhachhangController : Controller
    {
        // GET: Khachhang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThongtinKH()// khong can nhan ai id thong qua url get vi van de bao mat, userid lay tu session
        {
            
            int CusId=int.Parse(Session["CusId"].ToString());
            QLRPCNSEntities db = new QLRPCNSEntities();
            sp_Customer_GetById_Result KH = db.sp_Customer_GetById(CusId).FirstOrDefault();
            
            return View(KH);

              
        }

        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(Customer TKKH, HttpPostedFileBase uploadhinh)
        {
            QLRPCNSEntities db = new QLRPCNSEntities();
            sp_Customer_GetById_Result KH = new sp_Customer_GetById_Result();
            KH.CusId = TKKH.CusId;
            KH.FullName = TKKH.FullName;
            KH.Username = TKKH.Username;
            KH.Password = TKKH.Password;
            db.Customers.Add(TKKH);
            db.SaveChanges();

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.Customers.ToList().Last().CusId.ToString());
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "P" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/KHimages"), _FileName);
                uploadhinh.SaveAs(_path);

                Customer uP = db.Customers.FirstOrDefault(x => x.CusId == id);
                uP.Avata = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("DangNhap");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(Customer TKKH)
        {
            QLRPCNSEntities db = new QLRPCNSEntities();
            int id = TKKH.CusId;
            string name = TKKH.Username;

            Customer KH = db.Customers.Where(i => (i.Username == name) && (i.Password == TKKH.Password)).FirstOrDefault();

            if (KH != null)
            {
                
                Session["TrangThai"] = "1";
                Session["CusId"] = KH.CusId.ToString();       //Da luu trong session
                Session["Username"] = KH.Username.ToString();
                Session["Password"] = KH.Password.ToString();
                Session["Fullname"] = KH.FullName;
                Session["Email"] = KH.Email;
                Session["Phone"] = KH.Phone;


                //return RedirectToAction("ThongtinKH", new { CusId = KH.CusId }); //Khong can truyen Cusid vi action nay no se lay cusid tu session
                return RedirectToAction("ThongtinKH");
            }
            return RedirectToAction("DangNhap");



            /*
            var item = db.Customers.Where(i =>(i.Username == name) &&( i.Password == TKKH.Password)).FirstOrDefault();

            if (item != null)
            {
                if (item.Password == TKKH.Password)
                {
                    Session["TrangThai"] = "1";
                    Session["CusId"] = TKKH.CusId.ToString();       //Da luu trong session
                    Session["Username"] = TKKH.Username.ToString();
                    Session["Password"] = TKKH.Password.ToString();
                    Customer KH = db.Customers.Where (i =>(i.Username == name) && (i.Password == TKKH.Password)).FirstOrDefault();
                    if (KH != null)
                    {
                        Session["Fullname"] = KH.FullName;
                        Session["Email"] = KH.Email;
                        Session["Phone"] = KH.Phone;

                    }    
                    return RedirectToAction("ThongtinKH", new { CusId = item.CusId });

                }
            }
            return RedirectToAction("DangNhap");
            */
        }


        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("index", "home");

        }
        
        [HttpGet]
        public ActionResult SuaThongtinKH()
        {
            int CusId = int.Parse(Session["CusId"].ToString());
            QLRPCNSEntities DB = new QLRPCNSEntities();
            sp_Customer_GetById_Result KH = DB.sp_Customer_GetById(CusId).FirstOrDefault();

            return View(KH);


        }
        
        public ActionResult SuaThongtinKH(Customer a)
        {
            a.CusId = int.Parse(Session["CusId"].ToString());
            QLRPCNSEntities DB = new QLRPCNSEntities();
            Customer KH=DB.Customers.FirstOrDefault(c => c.CusId == a.CusId);
            //sp_Customer_GetById_Result KH = DB.sp_Customer_GetById(a.CusId).FirstOrDefault();
            KH.FullName = a.FullName;
            KH.Phone = a.Phone;
            KH.Email = a.Email;
            Session["Fullname"] = KH.FullName;
            Session["Email"] = KH.Email;
            Session["Phone"] = KH.Phone;
            //DB.sp_Customer_Update(KH.CusId, KH.Username, KH.CreditCard, KH.FullName, KH.Bod, KH.Address, KH.Phone, KH.Email, KH.Avata, KH.Status);
            DB.SaveChanges();
            //return RedirectToAction("ThongtinKH",new { id = a.CusId }); //Khong can truyen Cusid vi action nay no se lay cusid tu session
            return RedirectToAction("ThongtinKH");

        }


    }
}