using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.Repository
{
    public interface IComment
    {
        void AddCommentOnNews(News changedNews);
        void DeleteComment(Guid commentID);
    }
}
