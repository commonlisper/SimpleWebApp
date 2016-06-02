using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebApp.BusinessLogic.DTO;

namespace SimpleWebApp.BusinessLogic.Abstract
{
    public interface IArticleService
    {
        IEnumerable<ArticleDto> GetArticleDtoList();
        ArticleDto GetArticleDto(int id);
        ArticleDto Add(ArticleDto articleListItem);
        void Update(ArticleDto articleListItem);
        void Remove(int id);
    }
}
