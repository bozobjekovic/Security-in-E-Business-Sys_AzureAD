using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Context;
using WebMailService.Helpers;
using WebMailService.Model;

namespace WebMailService.Repository.DB
{
    public class EmailRepository : IEmail
    {
        private WebMailDBContext webMailDBContext = new WebMailDBContext();

        public void ComposeEmail(Email email)
        {
            webMailDBContext.Emails.Add(email);
            webMailDBContext.SaveChanges();
        }

        public void DeleteEmail(Guid emailID)
        {
            var email = webMailDBContext.Emails.FirstOrDefault(e => e.ID.Equals(emailID));
            webMailDBContext.Emails.Remove(email);
            webMailDBContext.SaveChanges();
        }

        public EmailDetails GetEmailDetails(User user, Guid emailID)
        {
            EmailDetails emailDetails = new EmailDetails();
            emailDetails.Email = webMailDBContext.Emails.First(e => e.ID.Equals(emailID));
            emailDetails.InboxNewMessages = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && !e.IsRead && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).Count();

            return emailDetails;
        }

        public EmailDetails GetInbox(User user)
        {
            EmailDetails emailDetails = new EmailDetails();
            emailDetails.Emails = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).OrderByDescending(e => e.Date).ToArray();
            emailDetails.TotalMessages = emailDetails.Emails.Count();
            emailDetails.InboxNewMessages = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && !e.IsRead && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).Count();

            return emailDetails;
        }

        public EmailDetails GetSent(User user)
        {
            EmailDetails emailDetails = new EmailDetails();
            emailDetails.Emails = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && e.From.Equals(user.Email)).OrderByDescending(e => e.Date).ToArray();
            emailDetails.TotalMessages = emailDetails.Emails.Count();
            emailDetails.InboxNewMessages = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && !e.IsRead && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).Count();

            return emailDetails;
        }

        public EmailDetails GetTrash(User user)
        {
            EmailDetails emailDetails = new EmailDetails();
            emailDetails.Emails = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && e.IsDeleted).OrderByDescending(e => e.Date).ToArray();
            emailDetails.TotalMessages = emailDetails.Emails.Count();
            emailDetails.InboxNewMessages = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && !e.IsRead && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).Count();

            return emailDetails;
        }

        public Email MoveToTrash(Guid emailID)
        {
            var email = webMailDBContext.Emails.FirstOrDefault(e => e.ID.Equals(emailID));
            email.IsDeleted = true;
            webMailDBContext.SaveChanges();
            return email;
        }

        public EmailDetails SearchEmailsByUsersEmailsAndSubjectAndMessages(User user, string searchWord)
        {
            var searchW = searchWord.ToUpper();

            EmailDetails emailDetails = new EmailDetails();
            emailDetails.Emails = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) &&
                                                 (e.From.ToUpper().Contains(searchW) ||
                                                 e.ReceiversEmail.Any(r => r.EmailAddress.ToUpper().Contains(searchW)) ||
                                                 e.Subject.ToUpper().Contains(searchW) ||
                                                 e.Message.ToUpper().Contains(searchW))).ToArray();
            emailDetails.TotalMessages = emailDetails.Emails.Count();
            emailDetails.InboxNewMessages = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && !e.IsRead && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).Count();

            return emailDetails;
        }

        public void SetAsRead(Guid emailID)
        {
            var email = webMailDBContext.Emails.First(e => e.ID == emailID);
            email.IsRead = true;
            webMailDBContext.SaveChanges();
        }
    }
}
