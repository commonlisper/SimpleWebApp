using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApp.BusinessLogic.DTO
{
    public class ArticlesResultDto
    {
        public IEnumerable<ArticleEditDto> Items { get; set; }
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
