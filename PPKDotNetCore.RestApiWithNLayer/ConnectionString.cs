using System.Data.SqlClient;

namespace PPKDotNetCore.RestApiWithNLayer
{
    internal static class ConnectionString
    {
        public static readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = @".\SQL2019E",
            InitialCatalog = "PPKDotNetTrainingBatch4",
            UserID = "sa",
            Password = "p@ssw0rd",
            TrustServerCertificate = true
        };
    }
}
