using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITNewsService.Helpers
{
    public class AddComment
    {
        public string Text { get; set; }
        public Guid NewsID { get; set; }
    }
}