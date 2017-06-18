using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNewsService.Model;
using ITNewsService.Repository;
using ITNewsService.Repository.DB;

namespace ITNewsService.BusinessLogic.Managers
{
    public class CommentManager : ICommentManager
    {
        private IComment commentDBRepository = new CommentRepository();
        private INews newsDBRepository = new NewsRepository();

        public void AddComment(Comment comment, Guid newsID)
        {
            News news = newsDBRepository.GetNews(newsID);
            news.Comments.Add(comment);
            newsDBRepository.AddCommentOnNews(news);
        }

        public void DeleteComment(Guid commentID)
        {
            commentDBRepository.DeleteComment(commentID);
        }
    }
}
