using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITNewsService.Models
{
    public class NewsViewModel
    {
        public ICollection<News> News { get; set; }
    }
}