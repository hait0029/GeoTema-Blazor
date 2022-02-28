using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;
        //Data adgang til bibliotek
        public string ConnectionStringName { get; set; } = "Default";
        
        //constructer
        public SqlDataAccess(IConfiguration config)
        {
            this.config = config;
        }
        //async metode bliver brugt til returnerer typisk en opgave eller en opgave<TResult>. Inde i en async-metode anvendes en vent-operatør på en opgave, der returneres fra et opkald til en anden async-metode
        public async Task<List<T>> LoadData<T, U>(string sql, U prarmeters)
        {

            string connectionString = config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, prarmeters);

                return data.ToList();
            }
        }
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);

            }
        }
    }
}
