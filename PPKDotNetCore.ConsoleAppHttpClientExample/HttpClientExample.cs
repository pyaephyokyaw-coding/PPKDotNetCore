using Newtonsoft.Json;
using PPKDotNetCore.ConsoleAppHttpClientExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PPKDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExample
    {
        private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7172") };
        private readonly string _blogEndpoint = "api/blog";

        public async Task RunAsync()
        {
            await GetAsync();
            await EditAsync(30);
            // await CreateAsync("HttpClientTitle", "HttpClientAuthor", "HttpClientContent");
        }

        private async Task GetAsync()
        {
            var response = await _httpClient.GetAsync(_blogEndpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<BlogDto> blogs = JsonConvert.DeserializeObject<List<BlogDto>>(jsonString)!;
                foreach (var blog in blogs)
                {
                    PrintBlogData(blog);
                }
            }
        }

        private async Task EditAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_blogEndpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            var blog = JsonConvert.DeserializeObject<BlogDto>(jsonString);
            PrintBlogData(blog!);

        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogDto requestBlog = new()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string blogJsonString = JsonConvert.SerializeObject(requestBlog);

            HttpContent httpContent = new StringContent(blogJsonString, Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync(_blogEndpoint, httpContent);
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogDto requestBlog = new()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string blogJsonString = JsonConvert.SerializeObject(requestBlog);

            HttpContent httpContent = new StringContent(blogJsonString, Encoding.UTF8, Application.Json);
            var response = await _httpClient.PutAsync($"{_blogEndpoint}/{id}", httpContent);
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        private async Task PatchAsync(int id, string title, string author, string content)
        {
            BlogDto requestBlog = new()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string blogJsonString = JsonConvert.SerializeObject(requestBlog);

            HttpContent httpContent = new StringContent(blogJsonString, Encoding.UTF8, Application.Json);
            var response = await _httpClient.PatchAsync($"{_blogEndpoint}/{id}", httpContent);
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }

        private async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_blogEndpoint}/{id}");

            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }


        private static void PrintBlogData(BlogDto blog)
        {
            Console.WriteLine("-------");
            Console.WriteLine("Id => " + blog.BlogId);
            Console.WriteLine("Title => " + blog.BlogTitle);
            Console.WriteLine("Author => " + blog.BlogAuthor);
            Console.WriteLine("Content => " + blog.BlogContent);
            Console.WriteLine("-------");
        }
    }
}