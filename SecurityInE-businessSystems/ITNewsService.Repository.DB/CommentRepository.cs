using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNewsService.Model;
using ITNewsService.Context;

namespace ITNewsService.Repository.DB
{
    public class CommentRepository : IComment
    {
        private ITNewsDBContext itNewsDBContext = new ITNewsDBContext();

        public void AddCommentOnNews(News changedNews)
        {
            itNewsDBContext.Entry(changedNews).State = System.Data.Entity.EntityState.Modified;
            itNewsDBContext.SaveChanges();
        }

        public void DeleteComment(Guid commentID)
        {
            var comment = itNewsDBContext.Comments.First(c => c.ID.Equals(commentID));
            itNewsDBContext.Comments.Remove(comment);
            itNewsDBContext.SaveChanges();
        }
    }
}
