using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMailService.Model;

namespace WebMailService.Helpers
{
    public class ParsedReceivers
    {
        public List<Guid> senderAndReceiversIDs { get; set; }
        public List<Receiver> Receivers { get; set; }

        public ParsedReceivers()
        {
            senderAndReceiversIDs = new List<Guid>();
            Receivers = new List<Receiver>();
        }
    }
}