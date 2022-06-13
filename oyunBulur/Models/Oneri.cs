using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oyunBulur.Models
{
    public class Oneri
    {
        
        public int Id { get; set; }
        public string OyunAdi { get; set; }
        public string OyunAciklama { get; set; }
        public int PerspektifID { get; set; }
        public int TurID { get; set; }
        public int TemaID { get; set; }
        public int PlatformID { get; set; }
        public int ModID { get; set; }




    }
}