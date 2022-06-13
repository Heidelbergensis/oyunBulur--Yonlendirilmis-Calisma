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
    public class AdminPaneliController : Controller
    {
        private readonly OyunContext db = new OyunContext();
        // GET: AdminPaneli
        // Admin paneli index sayfasındaki veriler viewbag'e atılr. 
        public ActionResult Index()
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
            // Liste indexte return edilir
            return View(oyun.ToList());
        }
        //Anapanel sayfası 
        public ActionResult AnaPanel()
        {
           
            return View();
        }
        public ActionResult Detay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oyun oyun = db.Oyun.Find(id);
            if (oyun == null)
            {
                return HttpNotFound();
            }
            return View(oyun);
        }

        // Admin panelinden oyun ekleme işlemini gerçekleştiren controller.
        [HttpGet]
        public ActionResult OyunEkle()
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


            return View();
        }
        // Oyun eklemenin POST işlemi.
        // Girilen veriler db'de yeni bir oyun satırı yaratır.
        [HttpPost]
        public ActionResult OyunEkle(Oyun poyn)
        {
            Oyun oyn = new Oyun();
            oyn.OyunAdi = poyn.OyunAdi;
            oyn.TurID = poyn.TurID;
            oyn.PerspektifID = poyn.PerspektifID;
            oyn.TemaID = poyn.TemaID;
            oyn.ModID = poyn.ModID;
            oyn.PlatformID = poyn.PlatformID;

            db.Oyun.Add(oyn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Admin paneli oyun silme işlemini gerçekleştiren controller.
        public ActionResult OyunSil()
        {
            List<SelectListItem> deger6 = (from i in db.Oyun.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.OyunAdi,
                                               Value = i.OyunID.ToString()
                                           }).ToList();
            ViewBag.dgr6 = deger6;
            return View();
        }

        // Oyun silme POST işlemi.
        // Oyun seçilen ID'ye bağlı olarak db'den silinir.
        [HttpPost]
        public ActionResult OyunSil(Oyun poyn)
        {
            Oyun oyn = new Oyun();

            oyn.OyunID = poyn.OyunID;
            db.Oyun.Attach(oyn);
            db.Oyun.Remove(oyn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Admin paneli oyun güncelleme işlemi.
        // Veriler View'de Viewbag ile sergilenir.
        public ActionResult OyunGuncelle(int? id)
        {

            List<SelectListItem> deger0 = (from i in db.Oyun.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.OyunAdi,
                                               Value = i.OyunID.ToString()
                                           }).ToList();
            ViewBag.dgr0 = deger0;

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
            // null ID kontrolü.
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oyun oyun = db.Oyun.Find(id);
            if (oyun == null)
            {
                return HttpNotFound();
            }

            return View(oyun);
        }

        // Oyun güncelleme POST işlemi.
        [HttpPost]

        public ActionResult OyunGuncelle(Oyun oyun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oyun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oyun);
        }
        //Admin paneli Mod ekleme GET işlemi.
        public ActionResult ModEkle()
        {
            return View();
        }
        // Mod ekleme POST işlemi.
        [HttpPost]
        public ActionResult ModEkle(Mod pmod)
        {
            Mod mod = new Mod();
            mod.ModAdi = pmod.ModAdi;


            db.Mod.Add(mod);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");

        }
        //Admin paneli Mod silme GET işlemi.
        public ActionResult ModSil()
        {
            List<SelectListItem> deger7 = (from i in db.Mod.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ModAdi,
                                               Value = i.ModID.ToString()
                                           }).ToList();
            ViewBag.dgr7 = deger7;
            return View();
        }

        // Mod silme POST işlemi.(ID'ye bağlı silme)
        [HttpPost]
        public ActionResult ModSil(Mod pmod)
        {
            Mod mod = new Mod();

            mod.ModID = pmod.ModID;
            db.Mod.Attach(mod);
            db.Mod.Remove(mod);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");
        }
        //Admin paneli Perspektif ekleme GET işlemi.
        public ActionResult PerspektifEkle()
        {
            return View();
        }
        //Admin paneli Perspektif ekleme POST işlemi.
        [HttpPost]
        public ActionResult PerspektifEkle(Perspektif pperspektif)
        {
            Perspektif perspektif = new Perspektif();
            perspektif.PerspektifAdi = pperspektif.PerspektifAdi;


            db.Perspektif.Add(perspektif);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");

        }
        //Admin paneli Perspektif silme GET işlemi.
        public ActionResult PerspektifSil()
        {
            List<SelectListItem> deger8 = (from i in db.Perspektif.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PerspektifAdi,
                                               Value = i.PerspektifID.ToString()
                                           }).ToList();
            ViewBag.dgr8 = deger8;
            return View();
        }
        //Admin paneli Perspektif silme POST işlemi.
        [HttpPost]
        public ActionResult PerspektifSil(Perspektif pperspektif)
        {
            Perspektif perspektif = new Perspektif();

            perspektif.PerspektifID = pperspektif.PerspektifID;
            db.Perspektif.Attach(perspektif);
            db.Perspektif.Remove(perspektif);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");
        }
        //Admin paneli Platform ekleme GET işlemi.
        public ActionResult PlatformEkle()
        {
            return View();
        }
        //Admin paneli Platform ekleme POST işlemi.
        [HttpPost]
        public ActionResult PlatformEkle(Platform pplatform)
        {
            Platform platform = new Platform();
            platform.PlatformAdi = pplatform.PlatformAdi;


            db.Platform.Add(platform);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");
        }
        //Admin paneli Platform silme GET işlemi.
        public ActionResult PlatformSil()
        {
            List<SelectListItem> deger9 = (from i in db.Platform.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PlatformAdi,
                                               Value = i.PlatformID.ToString()
                                           }).ToList();
            ViewBag.dgr9 = deger9;
            return View();
        }
        //Admin paneli Platform silme POST işlemi.
        [HttpPost]
        public ActionResult PlatformSil(Platform pplatform)
        {
            Platform platform = new Platform();

            platform.PlatformID = pplatform.PlatformID;
            db.Platform.Attach(platform);
            db.Platform.Remove(platform);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");
        }
        //Admin paneli Tema ekleme GET işlemi.
        public ActionResult TemaEKle()
        {
            return View();
        }
        //Admin paneli Tema ekleme POST işlemi.
        [HttpPost]
        public ActionResult TemaEKle(Tema ptema)
        {
            Tema tema = new Tema();
            tema.TemaAdi = ptema.TemaAdi;


            db.Tema.Add(tema);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");
        }
        //Admin paneli Tema silme GET işlemi.
        public ActionResult TemaSil()
        {
            List<SelectListItem> deger10 = (from i in db.Tema.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.TemaAdi,
                                                Value = i.TemaID.ToString()
                                            }).ToList();
            ViewBag.dgr10 = deger10;
            return View();
        }
        //Admin paneli Tema silme POST işlemi.
        [HttpPost]
        public ActionResult TemaSil(Tema ptema)
        {
            Tema tema = new Tema();

            tema.TemaID = ptema.TemaID;
            db.Tema.Attach(tema);
            db.Tema.Remove(tema);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Admin paneli Tür ekleme GET işlemi.
        public ActionResult TurEkle()
        {
            return View();
        }
        //Admin paneli Tür ekleme POST işlemi.
        [HttpPost]
        public ActionResult TurEkle(Tur ptur)
        {
            Tur tur = new Tur();
            tur.TurAdi = ptur.TurAdi;


            db.Tur.Add(tur);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");
        } 
        //Admin paneli Tür silme GET işlemi.

        public ActionResult TurSil()
        {
            List<SelectListItem> deger11 = (from i in db.Tur.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.TurAdi,
                                                Value = i.TurID.ToString()
                                            }).ToList();
            ViewBag.dgr11 = deger11;
            return View();
        }
        //Admin paneli Tür silme POST işlemi.
        [HttpPost]
        public ActionResult TurSil(Tur ptur)
        {
            Tur tur = new Tur();

            tur.TurID = ptur.TurID;
            db.Tur.Attach(tur);
            db.Tur.Remove(tur);
            db.SaveChanges();
            return RedirectToAction("AnaPanel");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Admin paneli Öneri Listeleme sayfası GET işlemi.
        //Kullanıcı önerileri bu sayfada listelenir

        public ActionResult OneriListe()
        {
            var model = db.Oneri;
            
            return View(model.ToList());
        }
        //Admin paneli Öneri Listeleme sayfası POST işlemi.
        //Kullanıcı önerilerini direk Oyun tablosuna ekleme işlemini gerçekleştirir.
        //Veri Oneri modelinden gelir, ekleme Oyun modeline yapılır.
        [HttpPost]
        public ActionResult OneriListe(Oneri model)
        {

            Oyun poyun = new Oyun();
            poyun.OyunAdi = model.OyunAdi;
            poyun.TurID = model.TurID;
            poyun.PerspektifID = model.PerspektifID;
            poyun.TemaID = model.TemaID;
            poyun.ModID = model.ModID;
            poyun.PlatformID = model.PlatformID;
            

            db.Oyun.Add(poyun);
            db.SaveChanges();
     
            return RedirectToAction("Index",model);

        }

    }
}