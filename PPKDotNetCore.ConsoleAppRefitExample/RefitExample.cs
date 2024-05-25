using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCore.ConsoleAppRefitExample
{
    public class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7172");
        public async Task RunAsync()
        {
            await ReadAsync();
            await EditAsync(30);
            //await EditAsync(200);
            //await CreateAsync("title", "author", "content");
            //await UpdateAsync(30,"title20","author20","content20");
            await PatchAsync(30, "25May title", null, "");
            await EditAsync(30);
            //await DeleteAsync(2016);
        }

        public async Task ReadAsync()
        {
            var lst = await _service.GetBlogs();

            foreach (var item in lst)
            {
                Console.WriteLine($"Id => {item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("--------------------------------------");
            }
        }

        public async Task EditAsync(int id)
        {
            try
            {
                var item = await _service.GetBlog(id);
                Console.WriteLine($"Id => {item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("--------------------------------------");

            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }

        public async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            var message = await _service.CreateBlog(blog);
            Console.WriteLine(message);
        }

        public async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            var message = await _service.UpdateBlog(id, blog);
            Console.WriteLine(message);
        }

        public async Task PatchAsync(int id, string? title, string? author, string? content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            var message = await _service.PatchBlog(id, blog);
            Console.WriteLine(message);
        }

        public async Task DeleteAsync(int id)
        {
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
    }
}
