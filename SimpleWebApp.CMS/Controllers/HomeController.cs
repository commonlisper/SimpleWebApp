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
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService = new ArticleService();

        // todo: need loose coupling
        //public HomeController(IRepository<Article> db)
        //{
        //    _articleDb = db;
        //}

        public ActionResult Index()
        {           
            return View(_articleService.GetArticleDtoList());
        }       
    }
}