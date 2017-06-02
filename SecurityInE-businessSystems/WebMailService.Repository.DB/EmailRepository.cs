using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Model;

namespace WebMailService.Repository.DB
{
    public class EmailRepository : IEmail
    {
        public Email ComposeEmail(Email email)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmail(Guid emailID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Email> GetInbox(Guid userID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Email> GetSent(Guid userID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Email> GetTrash(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Email MoveToTrash(Guid emailID)
        {
            throw new NotImplementedException();
        }
    }
}
