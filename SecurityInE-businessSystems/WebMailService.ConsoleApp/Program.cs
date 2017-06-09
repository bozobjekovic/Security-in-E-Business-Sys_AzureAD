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
        public static void CreateDataBase()
        {
            Email e1 = new Email()
            {
                From = "testU1@bozobjekovicgmail.onmicrosoft.com",
                ReceiversEmail = new List<Receiver>() { new Receiver() { EmailAddress = "testU2@bozobjekovicgmail.onmicrosoft.com" },
                                                        new Receiver() { EmailAddress = "testU3@bozobjekovicgmail.onmicrosoft.com" } },
                Date = DateTime.Now,
                Subject = "Test1",
                Message = "Test email 1",
                IsDeleted = false,
                IsRead = false,
                BelongsTo = Guid.Parse("a6faf790-783c-418f-91a0-652f6f020dca")
            };

            Email e11 = new Email()
            {
                From = "testU1@bozobjekovicgmail.onmicrosoft.com",
                ReceiversEmail = new List<Receiver>() { new Receiver() { EmailAddress = "testU2@bozobjekovicgmail.onmicrosoft.com" },
                                                        new Receiver() { EmailAddress = "testU3@bozobjekovicgmail.onmicrosoft.com" } },
                Date = DateTime.Now,
                Subject = "Test1",
                Message = "Test email 1",
                IsDeleted = false,
                IsRead = false,
                BelongsTo = Guid.Parse("bd7018e0-558d-4565-a215-36c3e31aef2b")
            };

            Email e12 = new Email()
            {
                From = "testU1@bozobjekovicgmail.onmicrosoft.com",
                ReceiversEmail = new List<Receiver>() { new Receiver() { EmailAddress = "testU2@bozobjekovicgmail.onmicrosoft.com" },
                                                        new Receiver() { EmailAddress = "testU3@bozobjekovicgmail.onmicrosoft.com" } },
                Date = DateTime.Now,
                Subject = "Test1",
                Message = "Test email 1",
                IsDeleted = false,
                IsRead = false,
                BelongsTo = Guid.Parse("240b3dfe-58c1-4240-a15e-df915a18047e")
            };


            Email e2 = new Email()
            {
                From = "testU2@bozobjekovicgmail.onmicrosoft.com",
                ReceiversEmail = new List<Receiver>() { new Receiver() { EmailAddress = "testU1@bozobjekovicgmail.onmicrosoft.com" } },
                Date = DateTime.Now.AddDays(10),
                Subject = "Test2",
                Message = "Test email 2",
                IsDeleted = false,
                IsRead = false,
                BelongsTo = Guid.Parse("a6faf790-783c-418f-91a0-652f6f020dca")
            };

            Email e21 = new Email()
            {
                From = "testU2@bozobjekovicgmail.onmicrosoft.com",
                ReceiversEmail = new List<Receiver>() { new Receiver() { EmailAddress = "testU1@bozobjekovicgmail.onmicrosoft.com" } },
                Date = DateTime.Now.AddDays(10),
                Subject = "Test2",
                Message = "Test email 2",
                IsDeleted = false,
                IsRead = false,
                BelongsTo = Guid.Parse("bd7018e0-558d-4565-a215-36c3e31aef2b")
            };

            WebMailDBContext wmDBc = new WebMailDBContext();

            Console.WriteLine("Insterting records ...");
            wmDBc.Emails.Add(e1);
            wmDBc.Emails.Add(e11);
            wmDBc.Emails.Add(e12);
            wmDBc.Emails.Add(e2);
            wmDBc.Emails.Add(e21);

            wmDBc.SaveChanges();

            Console.WriteLine("Insterting records finished!");

            foreach (var item in wmDBc.Emails.ToList())
            {
                wmDBc.Entry(item).Collection(u => u.ReceiversEmail).Load();
                foreach (var re in item.ReceiversEmail)
                {
                    Console.WriteLine(re.Email);
                }
            }
        }

        private static void TestDataBase()
        {
            IEmail emailRep = new EmailRepository();

            //var inboxMails = emailRep.GetTrash(new User() { ID = new Guid("00000000-0000-0000-0000-000000000000"), Email = "bozo.bjekovic@gmail.com" });
            //var iddxMails = emailRep.MoveToTrash(new Guid("9ECCE514-EC47-E711-B37B-38D547127E6E"));
            //var iasdasdoxMails = emailRep.GetTrash(new User() { ID = new Guid("00000000-0000-0000-0000-000000000000"), Email = "bozo.bjekovic@gmail.com" });
            //emailRep.DeleteEmail(new Guid("BBAD5294-5248-E711-B37B-38D547127E6E"));
            //var inb234oxMails = emailRep.GetSent(new User() { ID = new Guid("00000000-0000-0000-0000-000000000000"), Email = "bozo.bjekovic@gmail.com" });
        }

        static void Main(string[] args)
        {
            /**
             * sqllocaldb.exe stop MSSqlLocalDb
             * sqllocaldb.exe delete MSSqlLocalDb
            */
            CreateDataBase();

            Console.WriteLine("asdasd");
            Console.ReadKey();
        }
    }
}
