using ITNewsService.BusinessLogic;
using ITNewsService.BusinessLogic.Managers;
using ITNewsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITNewsService.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private INewsManager newsManager = new NewsManager();

        public ActionResult Index()
        {
            NewsViewModel newsVM = new NewsViewModel();
            newsVM.News = newsManager.GetAllNews();
            return View(newsVM);
        }

    }
}