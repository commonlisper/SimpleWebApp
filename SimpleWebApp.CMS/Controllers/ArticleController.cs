using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleWebApp.BusinessLogic;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
using SimpleWebApp.Domain;
using SimpleWebApp.Domain.EF;

namespace SimpleWebApp.CMS.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService = new ArticleService(
            new ArticlesRepository(new EfDbContext()), new MyMapper());        

        [HttpGet]
        public ActionResult Edit(int? id) =>
            id.HasValue
                ? View(_articleService.GetArticleEditDto(id.Value))
                : View();

        [HttpPost]
        public ActionResult Edit(ArticleEditDto articleEditDto)    
        {
            if (!ModelState.IsValid)
            {
                return View(articleEditDto);
            }

            if (articleEditDto.Id > 0)
            {
                _articleService.Update(articleEditDto);
            }
            else
            {
                _articleService.Add(articleEditDto);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditDescription(int id) =>
            View(_articleService.GetArticleDescriptionEditDto(id));
        

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