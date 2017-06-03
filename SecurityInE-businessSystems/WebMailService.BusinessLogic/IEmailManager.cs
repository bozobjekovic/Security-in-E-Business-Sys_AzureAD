using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Model;

namespace WebMailService.BusinessLogic
{
    public interface IEmailManager
    {
        void ComposeEmail(Email email, List<Guid> senderAndReceiversIDs);
        ICollection<Email> GetInbox(User user);
        ICollection<Email> GetSent(User user);
        ICollection<Email> GetTrash(User user);
        Email MoveToTrash(Guid emailID);
        void DeleteEmail(Guid emailID);
    }
}
