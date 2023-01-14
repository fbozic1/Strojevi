using Strojevi.Models;

namespace Strojevi.Data
{
    public interface IKvaroviData
    {

        Task<IEnumerable<GetKvarovi>> GetKvarovi(int? id, string? imestroja);

        Task<IEnumerable<GetKvarovi>> OdredeniBrojKvarova(int offset, int rows);

        Task<IEnumerable<GetKvarovi>> InsertKvarovi(KvaroviPost post);

        Task<IEnumerable<GetKvarovi>> UpdateKvarovi(KvaroviPut put);

        Task<IEnumerable<GetKvarovi>> UpdateStatusa(string statusKvara, int id);

        Task<IEnumerable<GetKvarovi>> DeleteKvarovi(int id);



    }
}
