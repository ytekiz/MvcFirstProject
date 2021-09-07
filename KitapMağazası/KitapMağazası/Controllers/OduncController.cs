using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitapMağazası.Models.Entity;

namespace KitapMağazası.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKITAP_MAĞAZASIEntities db = new DBKITAP_MAĞAZASIEntities();
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x=> x.ISLEMDURUM==false).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD +' '+ x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from y in db.TBLKITAP.Where(x=>x.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD  ,
                                               Value = y.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from z in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.PERSONEL,
                                               Value = z.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            var d1 = db.TBLUYELER.Where(x => x.ID == p.TBLUYELER.ID).FirstOrDefault();
            var d2 = db.TBLKITAP.Where(x => x.ID == p.TBLKITAP.ID).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(x => x.ID == p.PERSONEL).FirstOrDefault();
            p.TBLUYELER = d1;
            p.TBLKITAP = d2;
            

            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Odunciade(int id)
        {
            var odn = db.TBLHAREKET.Find(id);
            return View("Odunciade", odn);

        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrk= db.TBLHAREKET.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}