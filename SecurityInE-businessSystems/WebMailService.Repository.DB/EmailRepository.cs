using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Context;
using WebMailService.Model;

namespace WebMailService.Repository.DB
{
    public class EmailRepository : IEmail
    {
        private WebMailDBContext webMailDBContext = new WebMailDBContext();

        public void ComposeEmail(Email email, List<Guid> senderAndReceiversIDs)
        {
            foreach (var userID in senderAndReceiversIDs)
            {
                email.BelongsTo = userID;
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

        public ICollection<Email> GetInbox(User user)
        {
            return webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && e.ReceiversEmail.Any(r => r.EmailAddress.Equals(user.Email))).ToArray();
        }

        public ICollection<Email> GetSent(User user)
        {
            return webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && !e.IsDeleted && e.From.Equals(user.Email)).ToArray();
        }

        public ICollection<Email> GetTrash(User user)
        {
            return webMailDBContext.Emails.Where(e => e.BelongsTo.Equals(user.ID) && e.IsDeleted).ToArray();
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
