using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMailService.Model;
using WebMailService.Context;

namespace WebMailService.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Email e1 = new Email()
            {
                From = new Guid(),
                ReceiversIDs = new List<Receiver>() { new Receiver() { ObjectId = new Guid() } },
                Date = DateTime.Now,
                Subject = "Test1",
                Message = "Test email 1",
                IsDeleted = false,
                BelongsTo = new Guid()
            };


            Email e2 = new Email()
            {
                From = new Guid(),
                ReceiversIDs = new List<Receiver>() { new Receiver() { ObjectId = new Guid() } },
                Date = DateTime.Now.AddDays(10),
                Subject = "Test2",
                Message = "Test email 2",
                IsDeleted = false,
                BelongsTo = new Guid()
            };

            WebMailDBContext wmDBc = new WebMailDBContext();

            //Console.WriteLine("Insterting records ...");
            //wmDBc.Emails.Add(e1);
            //wmDBc.Emails.Add(e2);

            //wmDBc.SaveChanges();

            //Console.WriteLine("Insterting records finished!");

            foreach (var item in wmDBc.Emails.ToList())
            {
                wmDBc.Entry(item).Collection(u => u.ReceiversIDs).Load();
                foreach (var re in item.ReceiversIDs)
                {
                    Console.WriteLine(re.ObjectId);
                }
            }

            Console.ReadKey();
        }
    }
}
