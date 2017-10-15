using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBLOG.WEBUI.ViewModel
{
    public class CounterViewModel
    {
        public string KategoriAdi { get; set; }
        public int KategoridekiPostSayisi { get; set; }

        public int CatId { get; set; }
        public string CatDesc { get; set; }
    }
}