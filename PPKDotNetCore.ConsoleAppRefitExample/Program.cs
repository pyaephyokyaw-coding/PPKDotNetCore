using PPKDotNetCore.ConsoleAppRefitExample;
using Refit;

//var service = RestService.For<IBlogApi>("https://localhost:7172");
//var lst = await service.GetBlogs();
//foreach (var item in lst)
//{
//    Console.WriteLine($"Id => {item.BlogId}");
//    Console.WriteLine($"Title => {item.BlogTitle}");
//    Console.WriteLine($"Author => {item.BlogAuthor}");
//    Console.WriteLine($"Content => {item.BlogContent}");
//    Console.WriteLine("---------------------------");
//}

//Console.ReadLine();

//try
//{
//    RefitExample refitExample = new RefitExample();
//    await refitExample.RunAsync();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}

RefitExample refitExample = new RefitExample();
await refitExample.RunAsync();
Console.ReadLine();