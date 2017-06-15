﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNewsService.Model;
using ITNewsService.Repository;
using ITNewsService.Repository.DB;

namespace ITNewsService.BusinessLogic.Managers
{
    public class NewsManager : INewsManager
    {
        private INews newsDBRepository = new NewsRepository();

        public ICollection<News> GetAllNews()
        {
            return newsDBRepository.GetAllNews();
        }

        public News GetNewsDetails(Guid newsId)
        {
            return newsDBRepository.GetNewsDetails(newsId);
        }
    }
}
