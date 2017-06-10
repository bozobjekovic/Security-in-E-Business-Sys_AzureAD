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
        public string From { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
        public Guid BelongsTo { get; set; }

        public virtual ICollection<Receiver> ReceiversEmail { get; set; }

        public Email()
        {
        }

        public Email(Email email, Guid belongsTo, bool isRead)
        {
            From = email.From;
            Date = email.Date;
            Subject = email.Subject;
            Message = email.Message;
            IsRead = isRead;
            BelongsTo = belongsTo;
            ReceiversEmail = new List<Receiver>();
            AddReceivers(email.ReceiversEmail.ToList());
        }

        private void AddReceivers(List<Receiver> receivers)
        {
            foreach (var receiver in receivers)
            {
                ReceiversEmail.Add(new Receiver(receiver));
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, From: {1}, To: {2}, Date: {3}, Subject: {4}, Message: {5}, BelongsTo: {6}", 
                ID, From, ReceiversEmail.Count, Date, Subject, Message, BelongsTo);
        }
    }
}
