using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        private enum TypeEmailDetails { Inbox, Sent, Trash, EmailDetails }

        private ADClient adClient = new ADClient();
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

        // GET: Home/Trash
        public ActionResult Trash()
        {
            EmailDetails emailDetails = GetEmailDetailsForUser(TypeEmailDetails.Trash);
            EmailViewModel emailVM = new EmailViewModel("Trash", emailDetails);

            return View(emailVM);
        }

        // GET: Home/ViewEmail
        public ActionResult ViewEmail(Guid emailID, string selectedLabel)
        {
            EmailDetails emailDetails = GetEmailDetailsForUser(TypeEmailDetails.EmailDetails, emailID);
            EmailViewModel emailVM = new EmailViewModel(selectedLabel, emailDetails);

            return View(emailVM);
        }

        // GET: Home/MoveToTrash
        public ActionResult MoveToTrahs(Guid emailID, string selectedLabel)
        {
            if (selectedLabel.Equals("Trash"))
            {
                emailManager.DeleteEmail(emailID);
                return RedirectToAction("Trash");
            }

            emailManager.MoveToTrash(emailID);
            return selectedLabel.Equals("Inbox") ? RedirectToAction("Index") : RedirectToAction("Sent");
        }

        // POST: Home/Compose
        [HttpPost]
        public async Task<ActionResult> Compose(ComposeEmail composeEmail)
        {
            string[] receiversEmails = composeEmail.Receivers.Split(',');

            ParsedReceivers parsedReceivers = await GetParsedReceivers(receiversEmails);
            Email email = new Email()
            {
                From = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value,
                Date = DateTime.Now,
                Subject = composeEmail.Subject,
                Message = composeEmail.Message,
                ReceiversEmail = parsedReceivers.Receivers
            };
            emailManager.ComposeEmail(email, parsedReceivers.senderAndReceiversIDs);

            return RedirectToAction("Sent");
        }

        private async Task<ParsedReceivers> GetParsedReceivers(string[] receiversEmails)
        {
            ParsedReceivers parsedReceivers = new ParsedReceivers();
            // sender's id
            parsedReceivers.senderAndReceiversIDs.Add(Guid.Parse(ClaimsPrincipal.Current.FindFirst(urlType_objectidentifier).Value)); 

            foreach (var receiverEmail in receiversEmails)
            {
                Guid receiverID = await adClient.GetReceiverIDbyEmail(receiverEmail);
                if (!receiverID.Equals(Guid.Empty))
                {
                    parsedReceivers.senderAndReceiversIDs.Add(receiverID);
                    parsedReceivers.Receivers.Add(new Receiver() { EmailAddress = receiverEmail, ReceiverExists = true });
                }
                else
                {
                    parsedReceivers.Receivers.Add(new Receiver() { EmailAddress = receiverEmail, ReceiverExists = false });
                }
            }

            return parsedReceivers;
        }

        [NonAction]
        private EmailDetails GetEmailDetailsForUser(TypeEmailDetails type, Guid emailID = new Guid())
        {
            Model.User user = new Model.User()
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
                case TypeEmailDetails.EmailDetails:
                    return emailManager.GetEmailDetails(user, emailID);
                default:
                    return null;
            }
        }
    }
}