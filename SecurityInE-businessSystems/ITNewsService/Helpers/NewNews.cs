using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITNewsService.Helpers
{
    public class NewNews
    {
        public string Title { get; set; }
        public string ImageOption { get; set; }
        public string Content { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}