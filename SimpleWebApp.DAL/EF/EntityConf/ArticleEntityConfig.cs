using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.DAL.EF.EntityConf
{
    public class ArticleEntityConfig : EntityTypeConfiguration<Article>
    {
        public ArticleEntityConfig()
        {
            Property(p => p.Title).IsRequired();
            Property(p => p.Url).IsRequired();
        }
    }
}
