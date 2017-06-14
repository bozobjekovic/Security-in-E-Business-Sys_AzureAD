using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.Model
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Guid Publisher { get; set; }

        [Required]
        public News News { get; set; }
    }
}
