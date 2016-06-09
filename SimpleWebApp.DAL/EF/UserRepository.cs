using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleWebApp.Domain.Abstract;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.DAL.EF
{
    public class UserRepository : IUserRepository
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

        public User GetByEmailAndPassword(string email, string password) =>
            _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

        public User GetByEmail(string email) =>
            _db.Users.FirstOrDefault(u => u.Email == email);

        public void Save(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _db.Users.Add(user);
            _db.SaveChanges();
        }

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
