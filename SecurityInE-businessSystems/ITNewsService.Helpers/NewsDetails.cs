using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.Helpers
{
    public class NewsDetails
    {
        public int NumberOfComments { get; set; }
        public Model.News News { get; set; }
    }
}
