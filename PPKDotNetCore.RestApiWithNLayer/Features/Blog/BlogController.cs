using Microsoft.AspNetCore.Mvc;
using PPKDotNetCore.RestApiWithNLayer.Db;
using PPKDotNetCore.RestApiWithNLayer.Models;

namespace PPKDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bL_Blog;
        public BlogController()
        {
            _bL_Blog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _bL_Blog.GetBlog();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _bL_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            int result = _bL_Blog.CreateBlog(blog);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _bL_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("Data not found.");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogContent = blog.BlogContent;
            item.BlogAuthor = blog.BlogAuthor;

            var result = _bL_Blog.UpdateBlog(id, item);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _bL_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("Data not found.");
            }

            var result = _bL_Blog.PatchBlog(id, blog);
            string message = result > 0 ? "Patching Successful" : "Patching Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _bL_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("Data not found.");
            }

            var result = _bL_Blog.DeleteBlog(id);
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
