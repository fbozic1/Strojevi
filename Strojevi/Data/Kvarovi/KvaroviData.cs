using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strojevi.Models;
using Strojevi.Data;
using System.Reflection.PortableExecutable;
using System.Data.SqlClient;
using System.Data;
using Npgsql;

namespace Strojevi.Data
{
    public class KvaroviData : IKvaroviData
    {
        private readonly ISqlDataAccess _db;

        public KvaroviData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<GetKvarovi>> GetKvarovi(int? id, string? imestroja)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("SELECT * FROM Kvarovi /**where**/");

            if (!string.IsNullOrEmpty(imestroja))
                builder.Where("imestroja=@imestroja", new { imestroja });

            if (id != null)
                builder.Where("kvaroviid=@id", new { id });

            var kvarovi = _db.LoadDataQuery<GetKvarovi, dynamic>(selector.RawSql, selector.Parameters);
            return kvarovi;

        }


        public Task<IEnumerable<GetKvarovi>> InsertKvarovi(KvaroviPost post)
        {
            var builderConnectionString = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);
            IConfiguration _configuration = builderConnectionString.Build();
            var myConnectionString = _configuration.GetConnectionString("Default");

            var builder = new SqlBuilder();
            var parameters = new DynamicParameters();
            string imeStroja = post.imestroja;
            string? nazivKvara = post.nazivkvara;
            string prioritet = post.prioritet;
            DateTime datumPocetka = post.datumpocetka;
            DateTime? datumZavrsetka = post.datumzavrsetka;
            string opisKvara = post.opiskvara;
            string? statusKvara = post.statuskvara;

            using (IDbConnection db = new NpgsqlConnection(myConnectionString)) 
            { 
            var machineExist = db.QueryFirstOrDefault<GetKvarovi>("SELECT * FROM Kvarovi WHERE imestroja = @imestroja and statuskvara = 'ne' ", new { imeStroja });
            if (machineExist != null)
            {
                //Throw an error or return a message that the machine is active
                throw new Exception("Pokušavate unjeti kvar na stroj koji ima aktivan kvar !");
            }

            else
            {

                var selector = builder.AddTemplate("INSERT INTO Kvarovi(imestroja,nazivkvara,prioritet,datumpocetka,datumzavrsetka,opiskvara,statuskvara) " +
                "VALUES (@imestroja,@nazivkvara,@prioritet,@datumpocetka,@datumzavrsetka,@opiskvara,@statuskvara) ");



                parameters.Add("@imestroja", imeStroja);
                parameters.Add("@nazivkvara", nazivKvara);
                parameters.Add("@prioritet", prioritet);
                parameters.Add("@datumpocetka", datumPocetka);
                parameters.Add("@datumzavrsetka", datumZavrsetka);
                parameters.Add("@opiskvara", opisKvara);
                parameters.Add("@statuskvara", statusKvara);



                var strojeviInsert = _db.LoadDataQuery<GetKvarovi, dynamic>(selector.RawSql, parameters);

                return strojeviInsert;

            }
           }
        }

    }
}
