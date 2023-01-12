using Dapper;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace Strojevi.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }   


        public async Task<IEnumerable<T>> LoadDataQuery<T,U>(string query, U parameters, string connectionId = "default")
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

            var result = await dbConnection.QueryAsync<T>(query, parameters, null, 60, commandType: CommandType.Text);

            return result;

        }
    }
}
