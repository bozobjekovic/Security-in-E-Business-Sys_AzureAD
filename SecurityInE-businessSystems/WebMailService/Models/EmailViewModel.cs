using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMailService.Model;

namespace WebMailService.Models
{
    public class EmailViewModel
    {
        public string SelectedLabel { get; set; }
        public int InboxNewMessages { get; set; }
        public int TotalMessages { get; set; }
        public ICollection<Email> Emails { get; set; }

        public EmailViewModel()
        {
            
        }

        public EmailViewModel(int inboxNewMessages, int totalMessages, ICollection<Email> emails)
        {
            SelectedLabel = "Inbox";
            InboxNewMessages = inboxNewMessages;
            TotalMessages = totalMessages;
            Emails = emails;
        }

        public EmailViewModel(string selectedLabel, int inboxNewMessages, int totalMessages, ICollection<Email> emails)
        {
            SelectedLabel = selectedLabel;
            InboxNewMessages = inboxNewMessages;
            TotalMessages = totalMessages;
            Emails = emails;
        }
    }
}