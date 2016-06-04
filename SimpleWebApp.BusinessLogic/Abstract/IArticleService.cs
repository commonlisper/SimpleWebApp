using System.Collections.Generic;
using SimpleWebApp.BusinessLogic.DTO;

namespace SimpleWebApp.BusinessLogic.Abstract
{
    public interface IArticleService
    {
        ArticleViewItemDtoList GetArticleViewItems();
        ArticleEditDto GetArticleEdit(int id);
        ArticleDescriptionEditDto GetArticleDescriptionEdit(int id);
        void Save(ArticleEditDto edit);
        void UpdateDescription(ArticleDescriptionEditDto descriptionEdit); 
        void Remove(int id);
    }
}
