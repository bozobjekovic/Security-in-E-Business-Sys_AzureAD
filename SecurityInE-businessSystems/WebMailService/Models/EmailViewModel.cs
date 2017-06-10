using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMailService.Helpers;
using WebMailService.Model;

namespace WebMailService.Models
{
    public class EmailViewModel
    {
        public string SelectedLabel { get; set; }
        public int InboxNewMessages { get; set; }
        public int TotalMessages { get; set; }
        public Email Email { get; set; }
        public ICollection<Email> Emails { get; set; }

        public EmailViewModel()
        {
            
        }

        public EmailViewModel(EmailDetails emailDetails)
        {
            SelectedLabel = "Inbox";
            InboxNewMessages = emailDetails.InboxNewMessages;
            TotalMessages = emailDetails.TotalMessages;
            Emails = emailDetails.Emails;
        }

        public EmailViewModel(string selectedLabel, EmailDetails emailDetails)
        {
            SelectedLabel = selectedLabel;
            InboxNewMessages = emailDetails.InboxNewMessages;
            TotalMessages = emailDetails.TotalMessages;
            Emails = emailDetails.Emails;
            Email = emailDetails.Email;
        }

    }
}