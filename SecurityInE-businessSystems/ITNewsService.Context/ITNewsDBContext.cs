using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.Context
{
    public class ITNewsDBContext : DbContext
    {
        public ITNewsDBContext() : base("ITNewsServiceDB")
        {
        }

        public DbSet<News> News { get; set; }
    }
}
