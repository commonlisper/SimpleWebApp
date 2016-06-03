using System.Collections.Generic;
using SimpleWebApp.BusinessLogic.DTO;

namespace SimpleWebApp.BusinessLogic.Abstract
{
    public interface IArticleService
    {
        IEnumerable<ArticleViewItemDto> GetArticleViewItemsDto();
        ArticleEditDto GetArticleEditDto(int id);
        ArticleDescriptionEditDto GetArticleDescriptionEditDto(int id);
        void Add(ArticleEditDto dto);
        void Update(ArticleEditDto editDto); 
        void UpdateDescription(ArticleDescriptionEditDto descriptionEditDto); 
        void Remove(int id);
    }
}
