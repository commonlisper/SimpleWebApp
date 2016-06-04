using System.Collections.Generic;
using System.Linq;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
using SimpleWebApp.Domain.Abstract;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.BusinessLogic
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _repository;
        private readonly IMapper _mapper;

        public ArticleService(IRepository<Article> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ArticleViewItemDtoList GetArticleViewItems() =>
            new ArticleViewItemDtoList
            {
                Articles = _repository.GetAll()
                    .Select(
                        article =>
                            _mapper.Map<Article, ArticleViewItemDto>(article))
            };

        public ArticleEditDto GetArticleEdit(int id) =>
            _mapper.Map<Article, ArticleEditDto>(_repository.Get(id));

        public ArticleDescriptionEditDto GetArticleDescriptionEdit(int id) =>
            _mapper.Map<Article, ArticleDescriptionEditDto>(_repository.Get(id));        

        public void Save(ArticleEditDto edit)
        {
            if (edit.Id > 0)
            {
                _repository.Update(_mapper.Map<ArticleEditDto, Article>(edit));
            }
            else
            {
                _repository.Add(_mapper.Map<ArticleEditDto, Article>(edit));
            }
        }

        public void UpdateDescription(ArticleDescriptionEditDto descriptionEdit)
        {
            var article = _repository.Get(descriptionEdit.Id);

            if (article == null)
            {
                return;
            }

            article.Description = descriptionEdit.Description;

            _repository.Update(article);
        }

        public void Remove(int id) =>
            _repository.Remove(id);
    }
}
