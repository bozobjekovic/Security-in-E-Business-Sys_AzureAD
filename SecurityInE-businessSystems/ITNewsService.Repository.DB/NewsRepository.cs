using ITNewsService.Context;
using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.Repository.DB
{
    public class NewsRepository : INews
    {
        private ITNewsDBContext itNewsDBContext = new ITNewsDBContext();

        public ICollection<News> GetAllNews()
        {
            return itNewsDBContext.News.ToList();
        }

        public News GetNewsDetails(Guid newsId)
        {
            return itNewsDBContext.News.First(n => n.ID.Equals(newsId));
        }
    }
}
