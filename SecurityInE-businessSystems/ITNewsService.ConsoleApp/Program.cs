using ITNewsService.Context;
using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ITNewsDBContext itNewsContext = new ITNewsDBContext();

            Console.WriteLine("Hope it has been created! ");

            News news1 = new News()
            {
                Title = "Title1",
                Content = "Helloo message",
                Date = DateTime.Now,
                Publisher = new Guid(),
                Comments = new List<Comment>() {
                    new Comment() { Text = "TesxtCom1", Date = DateTime.Now.AddDays(2), Publisher = new Guid() }
                }
            };

            Console.WriteLine("Inserting records ...");
            itNewsContext.News.Add(news1);
            itNewsContext.SaveChanges();
            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }
}
