using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitapMağazası.Models.Entity;

namespace KitapMağazası.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKITAP_MAĞAZASIEntities db = new DBKITAP_MAĞAZASIEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLARR.Where(x => x.ALICI == uyemail.ToString()).ToList();

            return View(mesajlar);
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLARR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();

            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLARR t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLARR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesajlar");
        }
        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var gelensayisi = db.TBLMESAJLARR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = db.TBLMESAJLARR.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.d2 = gidensayisi;
            return PartialView();
        }
    }
}