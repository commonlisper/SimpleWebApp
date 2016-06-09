using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleWebApp.BusinessLogic;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
using SimpleWebApp.DAL.EF;

namespace SimpleWebApp.CMS.Controllers
{
    [Authorize]
    public class ArticleController : ApiController
    {
        private readonly IArticleService _articleService = new ArticleService(
            new ArticleRepository(new EfDbContext()), new MyMapper());

        //public ArticleController(IArticleService articleService)
        //{
        //    _articleService = articleService;
        //}        

        [HttpGet]
        public ArticleEditDto GetArticle(int id) =>
            _articleService.GetArticleEdit(id);

        [HttpPost]
        public ArticleEditDto Save(ArticleEditDto dto)
        {
            _articleService.Save(dto);

            return dto;
        }        
    }
}
