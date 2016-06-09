using System;
using System.Collections.Generic;
using System.Data.Entity;
using SimpleWebApp.Domain.Abstract;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.DAL.EF
{
    public class ArticlesRepository : IRepository<Article>
    {
        private readonly EfDbContext _db;
        
        public ArticlesRepository(EfDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Article> GetAll() =>
            _db.Articles;

        public Article Get(int id) =>
            _db.Articles.Find(id);        

        public void Add(Article item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _db.Articles.Add(item);
            _db.SaveChanges();            
        }

        public void Update(Article item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(int id)
        {
            Article article = _db.Articles.Find(id);

            if (article == null)
            {
                throw new NullReferenceException($"Article with id:{id} don't exist.");
            }

            _db.Articles.Remove(article);
            _db.SaveChanges();
        }
    }
}