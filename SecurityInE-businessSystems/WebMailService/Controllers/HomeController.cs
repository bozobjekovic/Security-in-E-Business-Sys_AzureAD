using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebMailService.BusinessLogic;
using WebMailService.BusinessLogic.Managers;

namespace WebMailService.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IEmailManager emailManager = new EmailManager();

        public ActionResult Index()
        {
            //emailManager.
            return View();
        }
    }
}