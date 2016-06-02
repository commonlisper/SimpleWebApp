using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleWebApp.BusinessLogic;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;

namespace SimpleWebApp.CMS.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService = new ArticleService();

        [HttpGet]
        public ActionResult Edit(int? id) =>
            id.HasValue
                ? View(_articleService.GetArticleDto(id.Value))
                : View();

        [HttpPost]
        public ActionResult Edit(ArticleDto articleDto)    
        {
            if (!ModelState.IsValid)
            {
                return View(articleDto);
            }

            if (articleDto.Id > 0)
            {
                _articleService.Update(articleDto);
            }
            else
            {
                _articleService.Add(articleDto);
            }

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