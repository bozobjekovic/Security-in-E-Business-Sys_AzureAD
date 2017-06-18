using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNewsService.Helpers;

namespace ITNewsService.BusinessLogic
{
    public interface INewsManager
    {
        ICollection<News> GetAllNews();
        NewsDetails GetNewsDetails(Guid newsId);
        void AddNews(News news);
        void AddComment(Comment comment, Guid newsID);
    }
}
