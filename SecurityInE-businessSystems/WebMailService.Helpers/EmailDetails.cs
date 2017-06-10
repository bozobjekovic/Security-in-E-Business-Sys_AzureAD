using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Model;

namespace WebMailService.Helpers
{
    public class EmailDetails
    {
        public ICollection<Email> Emails { get; set; }
        public int InboxNewMessages { get; set; }
        public int TotalMessages { get; set; }
        public Email Email { get; set; }
    }
}
