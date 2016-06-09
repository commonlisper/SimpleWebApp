using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.DAL.EF.EntityConf
{
    public class UserEntityConfig : EntityTypeConfiguration<User>
    {
        public UserEntityConfig()
        {
            Property(p => p.Email).IsRequired();
            Property(p => p.Password).IsRequired();
        }
    }
}
