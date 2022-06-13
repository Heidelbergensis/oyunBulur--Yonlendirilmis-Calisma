using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oyunBulur.Models;
using System.Net;
using System.Data.Entity;

namespace oyunBulur.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly OyunContext db = new OyunContext();
        // GET: Anasayfa
        //AramaIndex sayfası GET işlemi.

        public ActionResult AramaIndex()
        {
            var oyun = db.Oyun;
            return View(oyun.ToList());
        }
        //AramaIndex sayfası post işlemi.
        // Oyun İsmi içeriğindeki aramalar için filtre yapılır.
        //İşlemin sonucu (Return'ü) Sonuc sayfasına iletilir.
        [HttpPost]
        public ActionResult AramaIndex(string p)
        {
            var oyunlar = from o in db.Oyun select o;
            if (!string.IsNullOrEmpty(p))
            {
                oyunlar = oyunlar.Where(m => m.OyunAdi.Contains(p));
            }
            return View("~/Views/Anasayfa/Sonuc.cshtml", oyunlar);
        }
        //Sonuc sayfası aranan Oyun içeriğini listeler.
        public ActionResult Sonuc()
        {
            List<SelectListItem> deger1 = (from i in db.Tur.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.TurAdi,
                                               Value = i.TurID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Perspektif.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PerspektifAdi,
                                               Value = i.PerspektifID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from i in db.Tema.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.TemaAdi,
                                               Value = i.TemaID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            List<SelectListItem> deger4 = (from i in db.Mod.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ModAdi,
                                               Value = i.ModID.ToString()
                                           }).ToList();
            ViewBag.dgr4 = deger4;

            List<SelectListItem> deger5 = (from i in db.Platform.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PlatformAdi,
                                               Value = i.PlatformID.ToString()
                                           }).ToList();
            ViewBag.dgr5 = deger5;
            var oyun = db.Oyun;
            return View(oyun.ToList());
        }


    }
}