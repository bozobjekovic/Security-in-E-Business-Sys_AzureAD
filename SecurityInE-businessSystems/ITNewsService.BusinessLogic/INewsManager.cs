using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.BusinessLogic
{
    public interface INewsManager
    {
        ICollection<News> GetAllNews();
        News GetNewsDetails(Guid newsId);
    }
}
