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
    public class ContactSayfasiController : Controller
    {
        private readonly OyunContext db = new OyunContext();
        // GET: ContactSayfasi
        //İletişim sayfası Controlleri.
        //iletişim sayfasındaki bilgiler statiktir.
        public ActionResult Index()
        {
            return View();
        }
    }
}