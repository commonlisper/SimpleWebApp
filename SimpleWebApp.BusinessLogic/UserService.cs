using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
using SimpleWebApp.Domain.Abstract;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserLoginModelDto GetUserLoginModelDto(string email) =>
            _mapper.Map<User, UserLoginModelDto>(_repository.GetByEmail(email));

        public UserLoginModelDto GetUserLoginModelDto(string email, string password) =>
            _mapper.Map<User, UserLoginModelDto>(_repository.GetByEmailAndPassword(email, password));

        public void Save(UserRegisterModelDto user)
        {
            _repository.Save(_mapper.Map<UserRegisterModelDto, User>(user));
        }
    }
}
