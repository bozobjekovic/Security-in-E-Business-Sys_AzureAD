using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Helpers;
using WebMailService.Model;

namespace WebMailService.BusinessLogic
{
    public interface IEmailManager
    {
        void ComposeEmail(Email email, List<Guid> senderAndReceiversIDs);
        EmailDetails GetEmailDetails(User user, Guid emailID);
        EmailDetails GetInbox(User user);
        EmailDetails GetSent(User user);
        EmailDetails GetTrash(User user);
        Email MoveToTrash(Guid emailID);
        void DeleteEmail(Guid emailID);
        EmailDetails SearchEmails(User user, string searchWord);
    }
}
