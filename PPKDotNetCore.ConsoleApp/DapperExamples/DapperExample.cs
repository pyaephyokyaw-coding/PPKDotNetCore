using Dapper;
using PPKDotNetCore.ConsoleApp.Dtos;
using PPKDotNetCore.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCore.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(10);
            //Create("title", "author", "content");
            //Update(14, "title 2", "author 2", "content 2");
            Delete(14);
        }
        private void Read()
        {
            IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_Blog").ToList();

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
            IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from tbl_blog where blogid = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
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

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                   ([BlogTitle]
                                   ,[BlogAuthor]
                                   ,[BlogContent])
                             VALUES
                                   (@BlogTitle
                                   ,@BlogAuthor
                                   ,@BlogContent)";

            IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
        private void Update(int id, string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                             WHERE BlogId=@BlogId";

            IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            var item = new BlogDto
            {
                BlogId = id
            };

            string query = @"delete from tbl_blog where blogid = @blogid";

            IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
