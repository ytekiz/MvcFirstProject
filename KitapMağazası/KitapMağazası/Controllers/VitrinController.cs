using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitapMağazası.Models.Entity;
using KitapMağazası.Models.Siniflarim;

namespace KitapMağazası.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKITAP_MAĞAZASIEntities db = new DBKITAP_MAĞAZASIEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKITAP.ToList();
            cs.Deger2 = db.TBLHAKIMIZDA.ToList();
           // var degerler = db.TBLKITAP.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLILETIŞIM t)
        {
            db.TBLILETIŞIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult OzetGetir(int id)
        {
            var kitap = db.TBLKITAP.FirstOrDefault(x => x.ID == id);
            if (kitap != null)
            {
                return Json(kitap.OZET, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error Message", JsonRequestBehavior.AllowGet);
            }
        }
    }
}