using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMailService.Model
{
    public class Email
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid From { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public Guid BelongsTo { get; set; }

        public ICollection<Receiver> ReceiversIDs { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, From: {1}, To: {2}, Date: {3}, Subject: {4}, Message: {5}, BelongsTo: {6}", 
                ID, From, ReceiversIDs.Count, Date, Subject, Message, BelongsTo);
        }
    }
}
