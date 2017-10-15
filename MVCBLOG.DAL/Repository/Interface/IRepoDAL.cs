using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.DAL.Repository.Interface
{
    public interface IRepoDAL<T> where T : class
    {
        T IdIleGetir(int Id);
        List<T> TumListe();
        bool Kayit(T entity);
        bool Guncelle(T entity);
        bool PasifYap(T entity);
        bool SilDb(T entity);
    }
}
