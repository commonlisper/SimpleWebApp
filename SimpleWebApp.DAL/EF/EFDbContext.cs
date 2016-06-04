using System.Data.Entity;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.DAL.EF
{
    public class EfDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public EfDbContext() : base("EFConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Article>().Property(p => p.Url).IsRequired();

            base.OnModelCreating(modelBuilder);
        }       
    }
}