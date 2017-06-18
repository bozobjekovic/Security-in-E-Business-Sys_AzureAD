using ITNewsService.BusinessLogic;
using ITNewsService.BusinessLogic.Managers;
using ITNewsService.Helpers;
using ITNewsService.Model;
using ITNewsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ITNewsService.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private INewsManager newsManager = new NewsManager();

        private string urlType_objectidentifier = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        // GET: Home/Index
        [AllowAnonymous]
        public ActionResult Index()
        {
            NewsViewModel newsVM = new NewsViewModel();
            newsVM.News = newsManager.GetAllNews();
            return View(newsVM);
        }

        // POST: Home/AddNews
        [HttpPost]
        public ActionResult AddNews(NewNews newNews)
        {
            News news = new News()
            {
                Title = newNews.Title,
                Date = DateTime.Now,
                Content = newNews.Content,
                Publisher = Guid.Parse(ClaimsPrincipal.Current.FindFirst(urlType_objectidentifier).Value),
                Image = GetNewsImage(newNews.ImageOption)
            };
            newsManager.AddNews(news);
            
            return RedirectToAction("Index");
        }

        // GET: Home/NewsDetails
        [AllowAnonymous]
        public ActionResult NewsDetails(Guid id)
        {
            NewsDetails newsDetails = newsManager.GetNewsDetails(id);
            newsDetails.News.Comments = newsDetails.News.Comments.OrderByDescending(c => c.Date).ToList(); 
            NewsViewModel newsVM = new NewsViewModel(newsDetails);

            return View(newsVM);
        }

        // POST: Home/Comment
        [HttpPost]
        public ActionResult Comment(AddComment newComment)
        {
            Comment comment = new Comment()
            {
                Text = newComment.Text,
                Date = DateTime.Now,
                Publisher = Guid.Parse(ClaimsPrincipal.Current.FindFirst(urlType_objectidentifier).Value),
                PublisherName = ClaimsPrincipal.Current.FindFirst(ClaimTypes.GivenName).Value + " " + ClaimsPrincipal.Current.FindFirst(ClaimTypes.Surname).Value
            };
            newsManager.AddComment(comment, newComment.NewsID);

            return RedirectToAction("NewsDetails", new { id = newComment.NewsID });
        }

        private Image GetNewsImage(string imageOption)
        {
            Image image = null;

            if (imageOption.Equals("default"))
            {
                return new Image() { Name = "Default" };
            }
            else if (imageOption.Equals("empty"))
            {
                return image;
            }
            else
            {
                return image;
            }
        }

    }
}