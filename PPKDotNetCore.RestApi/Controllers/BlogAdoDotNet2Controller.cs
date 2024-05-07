using Dapper;
using Microsoft.AspNetCore.Mvc;
using PPKDotNetCore.RestApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using PPKDotNetCore.Shared;
using static PPKDotNetCore.Shared.AdoDotNetService;

namespace PPKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            var lst = _adoDotNetService.Query<List<BlogModel>>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogs(int id)
        {
            string query = "select * from tbl_blog where BlogId=@BlogId";

            AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            parameters[0] = new AdoDotNetParameter("@BlogId", id.ToString());
            var lst = _adoDotNetService.Query<List<BlogModel>>(query, parameters);

            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id.ToString()));

            if (item is null) return NotFound("No data found.");
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlogs(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                   ([BlogTitle]
                                   ,[BlogAuthor]
                                   ,[BlogContent])
                             VALUES
                                   (@BlogTitle
                                   ,@BlogAuthor
                                   ,@BlogContent)";

            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
            //return StatusCode(500, message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item == 0) return NotFound("Data not found.");
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                             WHERE BlogId=@BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlogs(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item == 0) return NotFound("Data not found.");
            string conditons = string.Empty;
            int conditionCount = 0;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditons += " [BlogTitle] = @BlogTitle, ";
                conditionCount++;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditons += " [BlogAuthor] = @BlogAuthor, ";
                conditionCount++;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditons += " [BlogContent] = @BlogContent, ";
                conditionCount++;
            }
            if (conditons.Length == 0)
            {
                return NotFound("No data to update.");
            }
            conditons = conditons.Substring(0, conditons.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                               SET {conditons}
                             WHERE BlogId=@BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (conditionCount == 1) cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            if (conditionCount == 2) cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            if (conditionCount == 3) cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlogs(int id)
        {
            var item = FindById(id);
            if (item == 0) return NotFound("Data not found.");
            string query = @"delete from tbl_blog where blogid = @blogid";

            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogid", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }

        private int FindById(int id)
        {
            string query = "select * from tbl_blog where BlogId=@BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
