using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMailService.Model
{
    public class Receiver
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public bool ReceiverExists { get; set; }

        [Required]
        public virtual Email Email { get; set; }

        public Receiver()
        {
        }

        public Receiver(Receiver receiver)
        {
            EmailAddress = receiver.EmailAddress;
            ReceiverExists = receiver.ReceiverExists;
        }
    }
}
