using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.DAL.Repository.Interface;
using System.Data.Entity;
using System.Linq.Expressions;
using MVCBLOG.DAL.Context;


namespace MVCBLOG.DAL.Repository.Class
{
    public class RepoDAL<T> : IRepoDAL<T> where T : class
    {

        #region Değişkenler

        private readonly BcMvcBlogDbContext context;
        private readonly DbSet<T> Dbset;

        #endregion

        #region Ctor
        public RepoDAL()

        {
            context = new BcMvcBlogDbContext();
            Dbset = context.Set<T>();
        }

        #endregion

        #region Select
        public T IdIleGetir(int Id)
        {
            return Dbset.Find(Id);
        }

        public int KayitSayisi()
        {
            return Dbset.Count();
        }

        public List<T> TumListe()
        {
            return Dbset.ToList();
        }

        public List<T> ListSorgulaDegereGore(Expression<Func<T, bool>> query)
        {
            return Dbset.Where(query).ToList();
        }

        public T NesneGetirDegereGore(Expression<Func<T, bool>> query)
        {
            return Dbset.Where(query).FirstOrDefault();
        }

        public IQueryable<T> TumListeQueryable()
        {
            return Dbset;
        }

        public T NesneGetirQueryable(Expression<Func<T, bool>> query)
        {
            return Dbset.FirstOrDefault();
        }

        #endregion

        #region Kayit
        public bool Kayit(T entity)
        {
            Dbset.Add(entity);
            //return _ctx.SaveChanges() > 0;
            if (context.SaveChanges() > 0)
            {
                //HttpContext.Current.Session[entity.ToString()] = entity;
                return true;
            }
            return false;
        }
        #endregion

        #region Guncelle
        public bool Guncelle(T entity)
        {
            Dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool PasifYap(T entity)
        {
            Dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        #endregion

        #region Sil
        public bool SilDb(T entity)
        {
            Dbset.Remove(entity);
            return context.SaveChanges() > 0;
        }
        #endregion

    }
}
