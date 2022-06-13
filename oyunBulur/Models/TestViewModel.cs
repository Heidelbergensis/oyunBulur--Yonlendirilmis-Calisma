using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyunBulur.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Oyun> Data { set; get; }
        public string SelectedStatus { set; get; }
        public string SelectedStatus2 { set; get; }
        public string SelectedStatus3 { set; get; }
        public string SelectedStatus4 { set; get; }
        public string SelectedStatus5 { set; get; }

    }
}