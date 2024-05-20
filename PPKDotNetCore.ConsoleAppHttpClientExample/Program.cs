using PPKDotNetCore.ConsoleAppHttpClientExamples;

Console.WriteLine("Program Started");

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();