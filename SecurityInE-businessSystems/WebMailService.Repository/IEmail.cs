using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Model;

namespace WebMailService.Repository
{
    public interface IEmail
    {
        Email ComposeEmail(Email email);
        ICollection<Email> GetInbox(Guid userID);
        ICollection<Email> GetSent(Guid userID);
        ICollection<Email> GetTrash(Guid userID);
        Email MoveToTrash(Guid emailID);
        void DeleteEmail(Guid emailID);
    }
}

/*
 * Methods:
    + composeMail()         ++
    + getInboxMails()       ++
    + getSentMails()        ++
    + getTrashMails()       ++
    + moveToTrashMail()     ++
    + deleteMail()          ++
    + searchMails()         
*/
