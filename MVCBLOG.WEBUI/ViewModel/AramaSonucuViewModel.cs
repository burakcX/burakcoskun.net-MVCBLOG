using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCBLOG.ENTITY.Model_DTO;

namespace MVCBLOG.WEBUI.ViewModel
{
    public class AramaSonucuViewModel
    {
        public int Adet { get; set; }
        public List<PostDTO> PostDtoList { get; set; }

    }
}