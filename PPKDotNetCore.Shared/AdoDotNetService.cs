using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPKDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;
        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<M> Query<M>(string query, AdoDotNetParameter[]? parameters = null)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                /*foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Name, item.Value);
                }*/
                //cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
                Array parametersArrays = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArrays);
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            List<M> lst = JsonConvert.DeserializeObject<List<M>>(json)!;
            return lst;
        }
        public M QueryFirstOrDefault<M>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                /*foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Name, item.Value);
                }*/
                //cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
                Array parametersArrays = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArrays);
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            var item = JsonConvert.DeserializeObject<M>(json)!;
            return item;
        }

        public class AdoDotNetParameter
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public AdoDotNetParameter(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
