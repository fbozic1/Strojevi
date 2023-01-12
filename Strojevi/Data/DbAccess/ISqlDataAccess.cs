

namespace Strojevi.Data
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataQuery<T, U>(string sqlQuery, U parameters, string connectionId = "Default");
    }
}
