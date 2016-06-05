using System.Collections.Generic;
using SimpleWebApp.BusinessLogic.DTO;

namespace SimpleWebApp.BusinessLogic.Abstract
{
    public interface IArticleService
    {
        ArticleViewItemDtoList GetArticleViewItems();
        ArticleEditDto GetArticleEdit(int id);
        void Save(ArticleEditDto edit);
        void Remove(int id);
    }
}
