using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyunBulur.Models
{
    public class Oyun
    {
        public int OyunID { get; set; }
        public string OyunAdi { get; set; }
        public string OyunAciklama { get; set; }
        public int PerspektifID { get; set; }
        public int TurID { get; set; }
        public int TemaID { get; set; }
        public int PlatformID { get; set; }
        public int ModID { get; set; }
        public string imgPath { get; set; }
        public string pagePath { get; set; }

  
     
        public Tema Temas { get; set; }
        public Mod Mods { get; set; }
        public Platform Platforms { get; set; }
        public Perspektif Perspektifs { get; set; }
        public Tur Turs { get; set; }


    }
}