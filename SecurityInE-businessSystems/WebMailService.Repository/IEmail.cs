using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Helpers;
using WebMailService.Model;

namespace WebMailService.Repository
{
    public interface IEmail
    {
        void ComposeEmail(Email email);
        EmailDetails GetEmailDetails(User user, Guid emailID);
        EmailDetails GetInbox(User user);
        EmailDetails GetSent(User user);
        EmailDetails GetTrash(User user);
        Email MoveToTrash(Guid emailID);
        void DeleteEmail(Guid emailID);
        void SetAsRead(Guid emailID);
        EmailDetails SearchEmailsByUsersEmailsAndSubjectAndMessages(User user, string searchWord);
    }
}
