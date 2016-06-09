using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebApp.BusinessLogic.DTO;

namespace SimpleWebApp.BusinessLogic.Abstract
{
    public interface IUserService
    {
        UserLoginModelDto GetUserLoginModelDto(string email);
        UserLoginModelDto GetUserLoginModelDto(string email, string password);
        void Save(UserRegisterModelDto user);
    }
}
