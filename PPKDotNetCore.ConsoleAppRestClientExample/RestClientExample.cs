using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PPKDotNetCore.ConsoleAppRestClientExample
{
    public class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7172"));
        private readonly string _blogEndpoint = "api/blog";

        public async Task RunAsync()
        {
            await GetAsync();
            await EditAsync(30);
            // await CreateAsync("HttpClientTitle", "HttpClientAuthor", "HttpClientContent");
        }

        private async Task GetAsync()
        {
            //RestRequest restRequest = new RestRequest(_blogEndpoint);
            //var response = await _client.GetAsync(restRequest);
            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content!;
                List<BlogDto> blogs = JsonConvert.DeserializeObject<List<BlogDto>>(jsonString)!;
                foreach (var blog in blogs)
                {
                    PrintBlogData(blog);
                }
            }
        }

        private async Task EditAsync(int id)
        {
            //var response = await _client.GetAsync($"{_blogEndpoint}/{id}");
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            if (!response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
            string jsonString = response.Content!;
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

            //string blogJsonString = JsonConvert.SerializeObject(requestBlog);
            //HttpContent httpContent = new StringContent(blogJsonString, Encoding.UTF8, Application.Json);
            //var response = await _client.PostAsync(_blogEndpoint, httpContent);

            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Post);
            restRequest.AddJsonBody(requestBlog);
            var response = await _client.ExecuteAsync(restRequest);
            string message = response.Content!;
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

            //string blogJsonString = JsonConvert.SerializeObject(requestBlog);
            //HttpContent httpContent = new StringContent(blogJsonString, Encoding.UTF8, Application.Json);
            //var response = await _client.PutAsync($"{_blogEndpoint}/{id}", httpContent);

            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            restRequest.AddJsonBody(requestBlog);
            var response = await _client.ExecuteAsync(restRequest);
            string message = response.Content!;
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

            //string blogJsonString = JsonConvert.SerializeObject(requestBlog);
            //HttpContent httpContent = new StringContent(blogJsonString, Encoding.UTF8, Application.Json);
            //var response = await _client.PatchAsync($"{_blogEndpoint}/{id}", httpContent);

            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Patch);
            restRequest.AddJsonBody(requestBlog);
            var response = await _client.ExecuteAsync(restRequest);
            string message = response.Content!;
            Console.WriteLine(message);
        }

        private async Task DeleteAsync(int id)
        {
            //var response = await _client.DeleteAsync($"{_blogEndpoint}/{id}");

            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(restRequest);
            string message = response.Content!;
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