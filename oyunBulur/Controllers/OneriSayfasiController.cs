using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oyunBulur.Models;
using System.Net;
using System.Data.Entity;
using System.Dynamic;


namespace oyunBulur.Controllers
{
    public class OneriSayfasiController : Controller
    {
        // GET: OneriSayfasi
        private readonly OyunContext db = new OyunContext();
        //Öneri sayfası GET işlemi.
        //Kullanıcılar önermek istediği kriterleri girer.
        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> deger01 = (from i in db.Tur.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.TurAdi,
                                                Value = i.TurID.ToString()
                                            }).ToList();
            ViewBag.dgr01 = deger01;

            List<SelectListItem> deger02 = (from i in db.Perspektif.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.PerspektifAdi,
                                                Value = i.PerspektifID.ToString()
                                            }).ToList();
            ViewBag.dgr02 = deger02;

            List<SelectListItem> deger03 = (from i in db.Tema.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.TemaAdi,
                                                Value = i.TemaID.ToString()
                                            }).ToList();
            ViewBag.dgr03 = deger03;

            List<SelectListItem> deger04 = (from i in db.Mod.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.ModAdi,
                                                Value = i.ModID.ToString()
                                            }).ToList();
            ViewBag.dgr04 = deger04;

            List<SelectListItem> deger05 = (from i in db.Platform.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.PlatformAdi,
                                                Value = i.PlatformID.ToString()
                                            }).ToList();
            ViewBag.dgr05 = deger05;


            return View();
        }
        //Post işlemi kullanıcılar tarafından önerilenleri öneri tablosuna ekler.
        [HttpPost]
        public ActionResult Index(Oneri poneri)
        {
            Oneri oneri = new Oneri();
            oneri.OyunAdi = poneri.OyunAdi;
            oneri.TurID = poneri.TurID;
            oneri.PerspektifID = poneri.PerspektifID;
            oneri.TemaID = poneri.TemaID;
            oneri.ModID = poneri.ModID;
            oneri.PlatformID = poneri.PlatformID;

            db.Oneri.Add(oneri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}