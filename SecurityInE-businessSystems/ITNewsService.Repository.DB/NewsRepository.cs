using ITNewsService.Context;
using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNewsService.Helpers;

namespace ITNewsService.Repository.DB
{
    public class NewsRepository : INews
    {
        private ITNewsDBContext itNewsDBContext = new ITNewsDBContext();

        public void AddCommentOnNews(News changedNews)
        {
            itNewsDBContext.Entry(changedNews).State = System.Data.Entity.EntityState.Modified;
            itNewsDBContext.SaveChanges();
        }

        public void AddNews(News news)
        {
            itNewsDBContext.News.Add(news);
            itNewsDBContext.SaveChanges();
        }

        public ICollection<News> GetAllNews()
        {
            return itNewsDBContext.News.OrderByDescending(n => n.Date).ToList();
        }

        public News GetNews(Guid newsId)
        {
            return itNewsDBContext.News.First(n => n.ID.Equals(newsId));
        }

        public NewsDetails GetNewsDetails(Guid newsId)
        {
            NewsDetails newsDetails = new NewsDetails();
            newsDetails.News = itNewsDBContext.News.First(n => n.ID.Equals(newsId));
            newsDetails.NumberOfComments = newsDetails.News.Comments.Count;

            return newsDetails;
        }
    }
}
