using System.Data.Entity;
using SimpleWebApp.DAL.EF.EntityConf;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.DAL.EF
{
    public class EfDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        public EfDbContext() : base("EFConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfDbContext,
            //    Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticleEntityConfig());
            modelBuilder.Configurations.Add(new UserEntityConfig());            

            base.OnModelCreating(modelBuilder);
        }       
    }
}