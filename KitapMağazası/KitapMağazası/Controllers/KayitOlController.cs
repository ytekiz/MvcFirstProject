using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitapMağazası.Models.Entity;

namespace KitapMağazası.Controllers
{
     [AllowAnonymous]
    public class KayitOlController : Controller
    {
     
        // GET: KayitOl
        DBKITAP_MAĞAZASIEntities db = new DBKITAP_MAĞAZASIEntities();
       [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit (TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}