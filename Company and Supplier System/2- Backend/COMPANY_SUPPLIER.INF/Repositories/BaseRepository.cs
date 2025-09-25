using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace COMPANY_SUPPLIER.INF.Repositories
{
    public class BaseRepository
    {
        protected readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            (_configuration) = (configuration);
        }

        private string ConnectionStringBase()
        {
            return _configuration.GetConnectionString(_configuration.GetSection("Base").Value.ToLower());
        }

        protected async Task Execute(string procedure, DynamicParameters parameters)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionStringBase());
                await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 0);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message); // all cases handled the same
            }
        }

        protected async Task<List<T>> Query<T>(string procedure, DynamicParameters parameters)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionStringBase());
                return (await connection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure)).AsList();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
