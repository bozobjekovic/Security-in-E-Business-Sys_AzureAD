using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebMailService.BusinessLogic;
using WebMailService.BusinessLogic.Managers;
using WebMailService.Helpers;
using WebMailService.Model;
using WebMailService.Models;

namespace WebMailService.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private enum TypeEmailDetails { Inbox, Sent, Trash }
        private IEmailManager emailManager = new EmailManager();

        private string urlType_objectidentifier = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        public ActionResult Index()
        {
            EmailDetails emailDetails = GetEmailDetailsForUser(TypeEmailDetails.Inbox);
            EmailViewModel emailVM = new EmailViewModel(emailDetails);

            return View(emailVM);
        }

        // GET: Home/Sent
        public ActionResult Sent()
        {
            EmailDetails emailDetails = GetEmailDetailsForUser(TypeEmailDetails.Sent);
            EmailViewModel emailVM = new EmailViewModel("Sent", emailDetails);

            return View(emailVM);
        }

        // GET: Email/Trash
        public ActionResult Trash()
        {
            EmailDetails emailDetails = GetEmailDetailsForUser(TypeEmailDetails.Trash);
            EmailViewModel emailVM = new EmailViewModel("Trash", emailDetails);

            return View(emailVM);
        }

        [NonAction]
        private EmailDetails GetEmailDetailsForUser(TypeEmailDetails type)
        {
            User user = new User()
            {
                ID = Guid.Parse(ClaimsPrincipal.Current.FindFirst(urlType_objectidentifier).Value),
                Email = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value
            };

            switch (type)
            {
                case TypeEmailDetails.Inbox:
                    return emailManager.GetInbox(user);
                case TypeEmailDetails.Sent:
                    return emailManager.GetSent(user);
                case TypeEmailDetails.Trash:
                    return emailManager.GetTrash(user);
                default:
                    return null;
            }
        }
    }
}