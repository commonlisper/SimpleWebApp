﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleWebApp.Domain.Abstract;
using SimpleWebApp.Domain.EF;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.Domain
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

        public Article Add(Article item)
        {
            _db.Articles.Add(item);
            _db.SaveChanges();

            return item;
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
                return;
            }

            _db.Articles.Remove(article);
            _db.SaveChanges();
        }
    }
}