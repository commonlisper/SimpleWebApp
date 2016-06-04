using System.Data.Entity;
using SimpleWebApp.DAL.Entities;

namespace SimpleWebApp.DAL.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("EFConnection")
        {

        }

        public DbSet<Article> Articles { get; set; }        
    }
}