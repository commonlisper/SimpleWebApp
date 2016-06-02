using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
using SimpleWebApp.Domain;
using SimpleWebApp.Domain.Abstract;
using SimpleWebApp.Domain.Entities;
using SimpleWebApp.Domain.EF;

namespace SimpleWebApp.BusinessLogic
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _repository;

        public ArticleService(/*IRepository<Article> repository*/)
        {
            _repository = new ArticlesRepository(new EfDbContext());
            //_repository = repository;
        }

        public IEnumerable<ArticleDto> GetArticleDtoList() =>
            _repository.GetAll().Select(ArticleToDto).ToList();

        public ArticleDto GetArticleDto(int id) =>
             ArticleToDto(_repository.Get(id));

        public ArticleDto Add(ArticleDto articleView)
        {
            _repository.Add(DtoToArticle(articleView));

            return articleView;
        }

        public void Update(ArticleDto articleView) =>        
            _repository.Update(DtoToArticle(articleView));
        
        public void Remove(int id) =>        
            _repository.Remove(id);        

        private ArticleDto ArticleToDto(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            return new ArticleDto
            {                
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                Url = article.Url
            };
        }

        private Article DtoToArticle(ArticleDto articleDto)
        {
            if (articleDto == null)
            {
                throw new ArgumentNullException(nameof(articleDto));
            }

            return new Article
            {
                Id = articleDto.Id,
                Title = articleDto.Title,
                Description = articleDto.Description,
                Url = articleDto.Url
            };
        }
    }
}
