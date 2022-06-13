using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oyunBulur.Models;
using System.Net;
using System.Data.Entity;
using System.Dynamic;

public class TestSayfasiController : Controller
{
    private readonly OyunContext db = new OyunContext();
    // GET: Test
        //Detaylı Arama(Test) Sayfası
        //Veriler Viewbag'e atılır.
        
    public ActionResult Index(string selectedStatus = "",string selectedStatus2="", string selectedStatus3 = "", string selectedStatus4 = "", string selectedStatus5 = "")
    {
        var vm = new TestViewModel();


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

        var data = db.Oyun.ToList();
        //Parametrelerin Null durumu kontrol edilir.
        if (!String.IsNullOrEmpty(selectedStatus))
        {
            if (!String.IsNullOrEmpty(selectedStatus2))
            {
                if (!String.IsNullOrEmpty(selectedStatus3))
                {
                    if (!String.IsNullOrEmpty(selectedStatus4))
                    {
                        if (!String.IsNullOrEmpty(selectedStatus5))
                        {
                            //parametrelere uyum şartı girilir. (&& bağlacı)
                            data = data.Where(x => x.Turs.TurID.ToString() == selectedStatus
                             && x.Temas.TemaID.ToString() == selectedStatus2
                             && x.Mods.ModID.ToString() == selectedStatus3
                             && x.Platforms.PlatformID.ToString() == selectedStatus4
                             && x.Perspektifs.PerspektifID.ToString() == selectedStatus5
                            
                             ).ToList();
                        
                        }
                    }
                }
            }
        }
        //Sonuçta detaylı arama listelenir.

        vm.Data = data.ToList();
      
        return View(vm);


    }

}
