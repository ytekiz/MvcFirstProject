using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KitapMağazası.Models.Entity;

namespace KitapMağazası.Controllers
{  
    [Authorize]
    public class PanelimController : Controller
    {
        DBKITAP_MAĞAZASIEntities db = new DBKITAP_MAĞAZASIEntities();
       

        // GET: Panelim
        [HttpGet]
     
        public ActionResult Index()
        {
            var uyemail = (string)Session["mail"];
            //var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var degerler = db.TBLDUYURULAR.ToList();
            var d1 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.AD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;
           
            var d3 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.FOTOĞRAF).FirstOrDefault();
            ViewBag.d3 = d3;
            var d4 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;
            var d5 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d5 = d5;
            var d6 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;
            var d7 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d7 = d7;
            var uyeid = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.ID).FirstOrDefault();
            var d8 = db.TBLHAREKET.Where(x => x.UYE == uyeid).Count();
            ViewBag.d8 = d8;
            var d9 = db.TBLMESAJLARR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d9 = d9;
            var d10 = db.TBLDUYURULAR.Count();
            ViewBag.d10 = d10;

            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanıci = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanıci);
            uye.SIFRE = p.SIFRE;
            uye.FOTOĞRAF = p.FOTOĞRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarım()
        {
            return View();
        }
      public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
      public PartialViewResult Partial3()
        {
            var kullanıci = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanıci).Select(y => y.ID).FirstOrDefault();
            var uyebul = db.TBLUYELER.Find(id);
            return PartialView("Partial3", uyebul);
        }
    }
}