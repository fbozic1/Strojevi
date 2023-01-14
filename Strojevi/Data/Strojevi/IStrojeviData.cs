using Strojevi.Models;

namespace Strojevi.Data
{
    public interface IStrojeviData
    {
        Task<IEnumerable<GetStrojevi>> GetStrojevi(int? id, string? naziv);

        Task<IEnumerable<GetStrojevi>> DeleteStrojevi(int id);

        Task<IEnumerable<GetStrojevi>> InsertStrojevi(StrojeviPost post);

        Task<IEnumerable<GetStrojevi>> UpdateStrojevi(StrojeviPut put);



    }
}
