using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.Domain.Abstract;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.BusinessLogic
{
    public class UserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
