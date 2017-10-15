using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.BLL.UIServices.Interface
{
    public interface IBaseUIService<T> where T : class
    {
        List<T> TumListe();
        bool Kayit(T ModelDto);
        bool PasifYap(T ModelDto);
        bool SilDb(int Id);
        bool Guncelle(T ModelDto);
    }
}
