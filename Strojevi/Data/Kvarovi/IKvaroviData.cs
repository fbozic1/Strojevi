using Strojevi.Models;

namespace Strojevi.Data
{
    public interface IKvaroviData
    {

        Task<IEnumerable<GetKvarovi>> GetKvarovi(int? id, string? imestroja);

        Task<IEnumerable<GetKvarovi>> InsertKvarovi(KvaroviPost post);

    }
}
