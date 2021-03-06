﻿using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using SimpleWebApp.BusinessLogic;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
using SimpleWebApp.DAL.EF;

namespace SimpleWebApp.CMS.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService = new ArticleService(
            new ArticleRepository(new EfDbContext()), new MyMapper());

        public ActionResult Index()
        {
            return View("IndexSPA", _articleService.GetArticleViewItems());
        }

        [HttpGet]
        public ActionResult Edit(int? id) =>
            id.HasValue
                ? View("EditKnockout", _articleService.GetArticleEdit(id.Value))
                : View("EditKnockout");

        [HttpPost]
        public ActionResult Edit(ArticleEditDto articleEditDto)
        {
            try
            {
                _articleService.Save(articleEditDto);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbValidationError dbValidationError in ex.EntityValidationErrors
                    .SelectMany(validationError => validationError.ValidationErrors))
                {
                    ModelState.AddModelError(dbValidationError.PropertyName, dbValidationError.ErrorMessage);
                }

                return View(articleEditDto);
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