using System.Data.Entity;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.Domain.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("EFConnection")
        {

        }

        public DbSet<Article> Articles { get; set; }
    }
}