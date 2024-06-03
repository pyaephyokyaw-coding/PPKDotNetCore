using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCore.WinFormAppSqlInjection
{
    internal static class ConnectionStrings
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
