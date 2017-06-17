using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.Repository
{
    public interface INews
    {
        ICollection<News> GetAllNews();
        News GetNewsDetails(Guid newsId);
        void AddNews(News news);
    }
}
