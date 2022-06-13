using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oyunBulur.Models
{
    public class Sonuc
    {
        public int Id { get; set; }
        public IEnumerable<Tur> Tur { get; set; }
        public IEnumerable<Tema> Tema { get; set; }
        public IEnumerable<Mod> Mod { get; set; }
        public IEnumerable<Platform> Platform { get; set; }
        public IEnumerable<Perspektif> Perspektif { get; set; }
        public IEnumerable<Oyun> Oyun{ get; set; }
    }
}