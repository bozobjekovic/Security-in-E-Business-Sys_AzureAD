using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Helpers;
using WebMailService.Model;
using WebMailService.Repository;
using WebMailService.Repository.DB;

namespace WebMailService.BusinessLogic.Managers
{
    public class EmailManager : IEmailManager
    {
        private IEmail emailDBRepository = new EmailRepository();

        public void ComposeEmail(Email email, List<Guid> senderAndReceiversIDs)
        {
            emailDBRepository.ComposeEmail(email, senderAndReceiversIDs);
        }

        public void DeleteEmail(Guid emailID)
        {
            emailDBRepository.DeleteEmail(emailID);
        }

        public EmailDetails GetInbox(User user)
        {
            return emailDBRepository.GetInbox(user);
        }

        public EmailDetails GetSent(User user)
        {
            return emailDBRepository.GetSent(user);
        }

        public EmailDetails GetTrash(User user)
        {
            return emailDBRepository.GetTrash(user);
        }

        public Email MoveToTrash(Guid emailID)
        {
            return emailDBRepository.MoveToTrash(emailID);
        }
    }
}
