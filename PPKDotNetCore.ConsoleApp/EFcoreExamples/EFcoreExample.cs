using Dapper;
using PPKDotNetCore.ConsoleApp.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCore.ConsoleApp.EFcoreExamples
{
    internal class EFcoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            Read();
            Edit(12);
            //Create("title", "author", "content");
            Update(15, "title 3", "author 3", "content 3");
            Delete(18);
        }

        private void Read()
        {
            var lst = db.Blogs.ToList();

            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("-------------------------");
            }
        }
        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("-------------------------");
        }
        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("Data not found.");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = db.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("Data not found.");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
