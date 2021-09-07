﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitapMağazası.Models.Entity;

namespace KitapMağazası.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKITAP_MAĞAZASIEntities db = new DBKITAP_MAĞAZASIEntities();
        public ActionResult Index()
        {
            var degerler = db.TblKategori.Where(x=> x.DURUM== true).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult KategoriEkle(TblKategori p)
        {
            db.TblKategori.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TblKategori.Find(id);
            // db.TblKategori.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TblKategori.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TblKategori p)
        {
            var ktg = db.TblKategori.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return View("KategoriGetir", ktg);

        }
    }
}