using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Model;

namespace WebMailService.Context
{
    public class WebMailDBContext : DbContext
    {
        public WebMailDBContext() : base("WebMailServiceDB")
        {
        }

        public DbSet<Email> Emails { get; set; }
    }
}
