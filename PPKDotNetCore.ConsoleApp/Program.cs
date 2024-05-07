using PPKDotNetCore.ConsoleApp.EFcoreExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = @".\SQL2019E";
//stringBuilder.InitialCatalog = "PPKDotNetTrainingBatch4";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "p@ssw0rd";

//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
//connection.Open();
//Console.WriteLine("Connection open.");

//string query = "select * from tbl_blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection close.");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id => " + dr["BlogId"]);
//    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
//    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
//    Console.WriteLine("-----------------------------------");
//}

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Create("title", "author", "content");
////adoDotNetExample.Update(13, "test title", "test author", "test content");
////adoDotNetExample.Delete(13);
//adoDotNetExample.Edit(1000);
//adoDotNetExample.Edit(12);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

EFcoreExample eFcoreExample = new EFcoreExample();
eFcoreExample.Run();
Console.ReadLine();