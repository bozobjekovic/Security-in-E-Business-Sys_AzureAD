﻿using System;
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

        public void ComposeEmail(List<Email> emailsToDB)
        {
            foreach (var email in emailsToDB)
            {
                webMailDBContext.Emails.Add(email);
            }
            webMailDBContext.SaveChanges();
        }

        public void DeleteEmail(Guid emailID)
        {
            var email = webMailDBContext.Emails.FirstOrDefault(e => e.ID.Equals(emailID));
            webMailDBContext.Emails.Remove(email);
            webMailDBContext.SaveChanges();
        }

        public EmailDetails GetInbox(User user)
        {
            EmailDetails emailDetails = new EmailDetails();
            emailDetails.Emails = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).ToArray();
            emailDetails.TotalMessages = emailDetails.Emails.Count();
            emailDetails.InboxNewMessages = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && !e.IsRead && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).Count();

            return emailDetails;
        }

        public EmailDetails GetSent(User user)
        {
            EmailDetails emailDetails = new EmailDetails();
            emailDetails.Emails = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && e.From.Equals(user.Email)).ToArray();
            emailDetails.TotalMessages = emailDetails.Emails.Count();
            emailDetails.InboxNewMessages = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && !e.IsRead && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).Count();

            return emailDetails;
        }

        public EmailDetails GetTrash(User user)
        {
            EmailDetails emailDetails = new EmailDetails();
            emailDetails.Emails = webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && e.IsDeleted).ToArray();
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
    }
}
