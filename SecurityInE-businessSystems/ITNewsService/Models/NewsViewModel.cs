using ITNewsService.Model;
using ITNewsService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITNewsService.Models
{
    public class NewsViewModel
    {
        public News SelectedNews { get; set; }
        public int NuberOfComments { get; set; }

        public ICollection<News> News { get; set; }

        public NewsViewModel()
        {
        }

        public NewsViewModel(NewsDetails newsDetails)
        {
            SelectedNews = newsDetails.News;
            NuberOfComments = newsDetails.NumberOfComments;
        }
    }
}