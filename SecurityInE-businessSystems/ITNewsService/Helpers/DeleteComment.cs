using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITNewsService.Helpers
{
    public class DeleteComment
    {
        public Guid NewsID { get; set; }
        public Guid CommentID { get; set; }
    }
}