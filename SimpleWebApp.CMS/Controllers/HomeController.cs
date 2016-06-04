using System;
using System.Web.Mvc;
using SimpleWebApp.BusinessLogic;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
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
            return View(_articleService.GetArticleViewItems());
        }

        [HttpGet]
        public ActionResult Edit(int? id) =>
            id.HasValue
                ? View(_articleService.GetArticleEdit(id.Value))
                : View();

        [HttpPost]
        public ActionResult Edit(ArticleEditDto articleEditDto)
        {
            if (!ModelState.IsValid)
            {
                return View(articleEditDto);
            }

            _articleService.Save(articleEditDto);            

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditDescription(int id) =>
            View(_articleService.GetArticleDescriptionEdit(id));


        [HttpPost]
        public ActionResult EditDescription(ArticleDescriptionEditDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _articleService.UpdateDescription(dto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(nameof(id));
            }

            _articleService.Remove(id);

            return RedirectToAction("Index", "Home");
        }
    }
}