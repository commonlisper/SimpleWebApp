using System.Collections.Generic;
using System.Linq;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
using SimpleWebApp.DAL.Abstract;
using SimpleWebApp.DAL.Entities;

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

        public IEnumerable<ArticleViewItemDto> GetArticleViewItemsDto() =>
            _repository.GetAll()
                .Select(article => _mapper.Map<Article, ArticleViewItemDto>(article));

        public ArticleEditDto GetArticleEditDto(int id) =>
            _mapper.Map<Article, ArticleEditDto>(_repository.Get(id));

        public ArticleDescriptionEditDto GetArticleDescriptionEditDto(int id) =>
            _mapper.Map<Article, ArticleDescriptionEditDto>(_repository.Get(id));

        public void Add(ArticleEditDto dto)
        {
            _repository.Add(_mapper.Map<ArticleEditDto, Article>(dto));
        }

        public void Update(ArticleEditDto editDto)
        {
            _repository.Update(_mapper.Map<ArticleEditDto, Article>(editDto));
        }

        public void UpdateDescription(ArticleDescriptionEditDto descriptionEditDto)
        {
            var article = _repository.Get(descriptionEditDto.Id);

            if (article == null)
            {
                return;
            }

            article.Description = descriptionEditDto.Description;

            _repository.Update(article);
        }

        public void Remove(int id) =>
            _repository.Remove(id);
    }
}
