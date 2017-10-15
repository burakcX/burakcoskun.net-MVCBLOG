using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.ENTITY;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;

namespace MVCBLOG.BLL.UIServices.Interface
{
    interface IPostUIService : IBaseUIService<PostDTO>
    {
        List<PostDTO> PostListeleCatIdIle(int Id);
        PostDTO PostDetayGetirIdIle(int Id);
        PostDTO PostGetirKullaniciAdiIle(string User);
    }
}
