using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNewsService.Model;
using ITNewsService.Repository;
using ITNewsService.Repository.DB;
using ITNewsService.Helpers;

namespace ITNewsService.BusinessLogic.Managers
{
    public class NewsManager : INewsManager
    {
        private INews newsDBRepository = new NewsRepository();

        public void AddNews(News news)
        {
            newsDBRepository.AddNews(news);
        }

        public ICollection<News> GetAllNews()
        {
            return newsDBRepository.GetAllNews();
        }

        public NewsDetails GetNewsDetails(Guid newsId)
        {
            return newsDBRepository.GetNewsDetails(newsId);
        }
    }
}
