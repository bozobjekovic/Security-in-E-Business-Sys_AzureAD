using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITNewsService.Model
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }

        //[Required]
        //public virtual News News { get; set; }
    }
}
