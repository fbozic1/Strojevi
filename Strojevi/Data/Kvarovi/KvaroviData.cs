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
using Microsoft.Extensions.Hosting;

namespace Strojevi.Data
{
    public class KvaroviData : IKvaroviData
    {
        private readonly ISqlDataAccess _db;

        public KvaroviData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<GetKvarovi>> GetKvarovi(int? id, string? nazivstroja)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("SELECT * FROM Kvarovi /**where**/");

            if (!string.IsNullOrEmpty(nazivstroja))
                builder.Where("nazivstroja=@nazivstroja", new { nazivstroja });

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
            string nazivStroja = post.nazivstroja;
            string? nazivKvara = post.nazivkvara;
            string prioritet = post.prioritet;
            DateTime datumPocetka = post.datumpocetka;
            DateTime? datumZavrsetka = post.datumzavrsetka;
            string opisKvara = post.opiskvara;
            string? statusKvara = post.statuskvara;

            using (IDbConnection db = new NpgsqlConnection(myConnectionString)) 
            { 
            var machineExist = db.QueryFirstOrDefault<GetKvarovi>("SELECT * FROM Kvarovi WHERE nazivstroja = @nazivstroja and statuskvara = 'ne' ", new { nazivStroja });
            if (machineExist != null)
            {
                //Throw an error or return a message that the machine is active
                throw new Exception("Pokušavate unjeti kvar na stroj koji ima aktivan kvar !");
            }

            else
            {

                var selector = builder.AddTemplate("INSERT INTO Kvarovi(nazivstroja,nazivkvara,prioritet,datumpocetka,datumzavrsetka,opiskvara,statuskvara) " +
                "VALUES (@nazivstroja,@nazivkvara,@prioritet,@datumpocetka,@datumzavrsetka,@opiskvara,@statuskvara) ");



                parameters.Add("@nazivstroja", nazivStroja);
                parameters.Add("@nazivkvara", nazivKvara);
                parameters.Add("@prioritet", prioritet);
                parameters.Add("@datumpocetka", datumPocetka);
                parameters.Add("@datumzavrsetka", datumZavrsetka);
                parameters.Add("@opiskvara", opisKvara);
                parameters.Add("@statuskvara", statusKvara);



                var kvaroviInsert = _db.LoadDataQuery<GetKvarovi, dynamic>(selector.RawSql, parameters);

                return kvaroviInsert;

            }
           }
        }

        public Task<IEnumerable<GetKvarovi>> UpdateKvarovi(KvaroviPut put)
        {
            var builder = new SqlBuilder();
            var parameters = new DynamicParameters();
            int id = put.kvaroviid;
            string? nazivStroja = put.nazivstroja;
            string? nazivKvara = put.nazivkvara;
            string? prioritet = put.prioritet;
            DateTime? datumPocetka = put.datumpocetka;
            DateTime? datumZavrsetka = put.datumzavrsetka;
            string? opisKvara = put.opiskvara;



            var selector = builder.AddTemplate("UPDATE Kvarovi " +
                "SET nazivstroja=@nazivstroja, nazivkvara=@nazivkvara, prioritet=@prioritet, datumpocetka=@datumpocetka, datumzavrsetka=@datumzavrsetka,opiskvara=@opiskvara " +
                "WHERE kvaroviid=@id");

            parameters.Add("@id", id);
            parameters.Add("@nazivstroja", nazivStroja);
            parameters.Add("@nazivkvara", nazivKvara);
            parameters.Add("@prioritet", prioritet);
            parameters.Add("@datumpocetka", datumPocetka);
            parameters.Add("@datumzavrsetka", datumZavrsetka);
            parameters.Add("@opiskvara", opisKvara);


            var kvaroviUpdate = _db.LoadDataQuery<GetKvarovi, dynamic>(selector.RawSql, parameters);
            return kvaroviUpdate;

        }

        public Task<IEnumerable<GetKvarovi>> DeleteKvarovi (int id)
        {
            var builder = new SqlBuilder();

            var parameters = new DynamicParameters();

            var selector = builder.AddTemplate("DELETE FROM Kvarovi WHERE kvaroviid=@id");

            parameters.Add("@id", id);

            var kvaroviDelete = _db.LoadDataQuery<GetKvarovi,dynamic>(selector.RawSql,parameters); 
            return kvaroviDelete;
        }


        public Task<IEnumerable<GetKvarovi>> UpdateStatusa (string statusKvara, int id)
        {
            var builder = new SqlBuilder();

            var parameters = new DynamicParameters();

            var selector = builder.AddTemplate("UPDATE Kvarovi SET statuskvara = @statuskvara WHERE kvaroviid = @id");

            parameters.Add("@id", id);
            parameters.Add("@statuskvara", statusKvara);

            var kvaroviUpdateStatusa = _db.LoadDataQuery<GetKvarovi,dynamic> (selector.RawSql, parameters);

            return kvaroviUpdateStatusa;
        }

        public Task<IEnumerable<GetKvarovi>> OdredeniBrojKvarova(int offset, int rows)
        {
            var builder = new SqlBuilder();
            var parameters = new DynamicParameters();

            var selector = builder.AddTemplate("SELECT * FROM Kvarovi ORDER BY prioritet ASC, datumpocetka DESC offset @offset rows fetch next @rows rows only");

            parameters.Add("@offset", offset);
            parameters.Add("@rows", rows);

            var kvaroviOdredenBroj = _db.LoadDataQuery<GetKvarovi, dynamic>(selector.RawSql, parameters);

            return kvaroviOdredenBroj;
        }

    }
}
