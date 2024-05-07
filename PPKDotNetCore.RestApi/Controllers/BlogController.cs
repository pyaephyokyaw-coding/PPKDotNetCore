using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPKDotNetCore.RestApi.Db;
using PPKDotNetCore.RestApi.Models;
using System.Reflection.Metadata;

namespace PPKDotNetCore.RestApi.Controllers
{
    // https://localhost:3000 => domain url
    // api/blog => endpoint

    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BlogController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _appDbContext.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item );
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _appDbContext.Blogs.Add(blog);
            var result = _appDbContext.SaveChanges();

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                return NotFound("Data not found.");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogContent = blog.BlogContent;
            item.BlogAuthor = blog.BlogAuthor;
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("Data not found.");
            }
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            if(!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Patching Successful" : "Patching Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("Data not found.");
            }
            _appDbContext.Blogs.Remove(item);
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
