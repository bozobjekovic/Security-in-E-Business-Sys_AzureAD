using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Model;
using WebMailService.Context;
using WebMailService.Repository;
using WebMailService.Repository.DB;

namespace WebMailService.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmail emailRep = new EmailRepository();

            Email e1 = new Email()
            {
                From = "bozo.bjekovic@gmail.com",
                ReceiversEmail = new List<Receiver>() { new Receiver() { EmailAddress = "ana@gmail.com" },
                                                        new Receiver() { EmailAddress = "zvone@gmail.com" },
                                                        new Receiver() { EmailAddress = "nena@gmail.com" } },
                Date = DateTime.Now,
                Subject = "Test1",
                Message = "Test email 1",
                IsDeleted = false,
                IsRead = false,
                BelongsTo = new Guid()
            };


            Email e2 = new Email()
            {
                From = "bozo.bjekovic@gmail.com",
                ReceiversEmail = new List<Receiver>() { new Receiver() { EmailAddress = "ana@gmail.com" } },
                Date = DateTime.Now.AddDays(10),
                Subject = "Test2",
                Message = "Test email 2",
                IsDeleted = false,
                IsRead = false,
                BelongsTo = new Guid()
            };

            WebMailDBContext wmDBc = new WebMailDBContext();

            Console.WriteLine("Insterting records ...");
            wmDBc.Emails.Add(e1);
            wmDBc.Emails.Add(e2);

            wmDBc.SaveChanges();

            Console.WriteLine("Insterting records finished!");

            //var inboxMails = emailRep.GetTrash(new User() { ID = new Guid("00000000-0000-0000-0000-000000000000"), Email = "bozo.bjekovic@gmail.com" });
            //var iddxMails = emailRep.MoveToTrash(new Guid("9ECCE514-EC47-E711-B37B-38D547127E6E"));
            //var iasdasdoxMails = emailRep.GetTrash(new User() { ID = new Guid("00000000-0000-0000-0000-000000000000"), Email = "bozo.bjekovic@gmail.com" });
            //emailRep.DeleteEmail(new Guid("BBAD5294-5248-E711-B37B-38D547127E6E"));
            //var inb234oxMails = emailRep.GetSent(new User() { ID = new Guid("00000000-0000-0000-0000-000000000000"), Email = "bozo.bjekovic@gmail.com" });

            //foreach (var item in wmDBc.Emails.ToList())
            //{
            //    wmDBc.Entry(item).Collection(u => u.ReceiversEmail).Load();
            //    foreach (var re in item.ReceiversEmail)
            //    {
            //        Console.WriteLine(re.Email);
            //    }
            //}

            Console.ReadKey();
        }
    }
}
