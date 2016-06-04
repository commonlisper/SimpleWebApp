using System.Web.Mvc;
using SimpleWebApp.BusinessLogic;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.DAL;
using SimpleWebApp.DAL.EF;

namespace SimpleWebApp.CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService = new ArticleService(
            new ArticlesRepository(new EfDbContext()), new MyMapper());
        
        //public HomeController(IRepository<Article> db)
        //{
        //    _articleDb = db;
        //}

        public ActionResult Index()
        {           
            return View(_articleService.GetArticleViewItemsDto());
        }       
    }
}