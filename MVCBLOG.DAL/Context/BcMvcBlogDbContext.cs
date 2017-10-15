using System.Data.Entity;
using MVCBLOG.ENTITY.Model_Entity;

namespace MVCBLOG.DAL.Context
{
    public class BcMvcBlogDbContext : DbContext
    {

        #region DBSet
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        #endregion

        #region Ctor
        public BcMvcBlogDbContext()
            : base("name=BcMvcBlogDbConnectionString")
        {

        }
        #endregion

        #region Initialize

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
        //private class VeritabaniOlusturucu : CreateDatabaseIfNotExists<BcMvcBlogDbContext>
        //{
        //Database oluşmadan önce ki çalışan metoddur.
        //public override void InitializeDatabase(MIODbContext context)
        //{
        //    base.InitializeDatabase(context);
        //}
        //Database oluştuktan sonra ki çalışan metoddur.

        //protected override void Seed(BcMvcBlogDbContext context)
        //{

        //}
        //}

        #endregion

    }
}

