using System;
using System.Collections.Generic;
using System.Data.Entity;
using SimpleWebApp.Domain.Abstract;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.DAL.EF
{
    public class UserRepository : IRepository<User>
    {
        private readonly EfDbContext _db;

        public UserRepository(EfDbContext db)
        {
            _db = db;
        }

        public void Add(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _db.Users.Add(item);
            _db.SaveChanges();
        }

        public User Get(int id) =>
            _db.Users.Find(id);

        public IEnumerable<User> GetAll() =>
            _db.Users;

        public void Remove(int id)
        {
            User user = Get(id);

            if (user == null)
            {
                throw new NullReferenceException($"User with id:{id} don't exist.");
            }

            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void Update(User item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
