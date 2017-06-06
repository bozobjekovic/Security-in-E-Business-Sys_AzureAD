using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebMailService.BusinessLogic;
using WebMailService.BusinessLogic.Managers;
using WebMailService.Model;
using WebMailService.Models;

namespace WebMailService.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IEmailManager emailManager = new EmailManager();

        public ActionResult Index()
        {
            string a = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            User user = new User()
            {
                ID = Guid.Parse(ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value),
                Email = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value
            };
            ICollection<Email> emails = emailManager.GetInbox(user);
            EmailViewModel emailVM = new EmailViewModel(50, 5555, emails);
            return View(emailVM);
        }

        // GET: Email/Sent
        public ActionResult Sent()
        {
            return View();
        }

        // GET: Email/Trash
        public ActionResult Trash()
        {
            return View();
        }
    }
}