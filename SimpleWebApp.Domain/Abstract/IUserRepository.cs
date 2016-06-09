using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.Domain.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        User GetByEmailAndPassword(string email, string password);
        void Save(User user);
    }
}
