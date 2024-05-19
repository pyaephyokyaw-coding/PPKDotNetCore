using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json.Serialization;

namespace PPKDotNetCore.RestApiWithNLayer2.Features.DreamDictionary
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamDictionaryController : ControllerBase
    {
        private async Task<DreamDictionary> GetDataAsync()
        {
            var json = await System.IO.File.ReadAllTextAsync("DreamDictionary.json");
            var model = JsonConvert.DeserializeObject<DreamDictionary>(json);
            return model;
        }

        [HttpGet($"questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            return Ok(model.BlogHeader);
        }

        [HttpGet("questions/{question}")]
        public async Task<IActionResult> Questions(string question)
        {
            var model = await GetDataAsync();
            var result = from header in model.BlogHeader
                         join detail in model.BlogDetail
                          on header.BlogId equals detail.BlogId
                         where header.BlogTitle.Contains(question) || detail.BlogContent.Contains(question)
                         select detail;
            return Ok(result);
        }
    }

    public class DreamDictionary
    {
        public Blogheader[] BlogHeader { get; set; }
        public Blogdetail[] BlogDetail { get; set; }
    }

    public class Blogheader
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
    }

    public class Blogdetail
    {
        public int BlogDetailId { get; set; }
        public int BlogId { get; set; }
        public string BlogContent { get; set; }
    }
}
