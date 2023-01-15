
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strojevi.Models;

namespace Strojevi.Data;

    public class StrojeviData : IStrojeviData
    {
        private readonly ISqlDataAccess _db;

        public StrojeviData(ISqlDataAccess db)
        {
            _db = db;
        }

        //public Task<IEnumerable<GetStrojevi>> GetStrojevi(int? id, string? naziv) 
        //{
        //    var builder = new SqlBuilder();

        //    var selector = builder.AddTemplate("SELECT * FROM Strojevi /**where**/");
            
        //    if(!string.IsNullOrEmpty(naziv)) 
        //    builder.Where("naziv=@naziv", new { naziv });

        //    if(id!=null)
        //    builder.Where("strojeviid=@id", new { id });

        //    var strojevi = _db.LoadDataQuery<GetStrojevi, dynamic>(selector.RawSql, selector.Parameters);
        //    return strojevi;

        //}

    public Task<IEnumerable<GetStrojevi>> InsertStrojevi(StrojeviPost post)
    {
        var builder = new SqlBuilder();
        var parameters = new DynamicParameters();
        var naziv = post.naziv;

        var selector = builder.AddTemplate("INSERT INTO Strojevi(Naziv) VALUES (@naziv)");

        
        parameters.Add("@naziv", naziv);

        var strojeviInsert = _db.LoadDataQuery<GetStrojevi, dynamic>(selector.RawSql, parameters);

        return strojeviInsert;

    }

    public Task<IEnumerable<GetStrojevi>> UpdateStrojevi(StrojeviPut put)
    {
        var builder = new SqlBuilder();
        var parameters = new DynamicParameters();
        var naziv = put.naziv;
        var id = put.id;

        var selector = builder.AddTemplate("UPDATE Strojevi SET naziv=@naziv WHERE strojeviid=@id");


        parameters.Add("@naziv", naziv);
        parameters.Add("@id", id);


        var strojeviUpdate = _db.LoadDataQuery<GetStrojevi, dynamic>(selector.RawSql, parameters);

        return strojeviUpdate;

    }


    public Task<IEnumerable<GetStrojevi>> DeleteStrojevi(int id)
        {
            var builder = new SqlBuilder();
            var parameters = new DynamicParameters();    

            var selector = builder.AddTemplate("DELETE FROM Strojevi WHERE strojeviid = @id");

            parameters.Add("@id", id);

            var strojeviDelete = _db.LoadDataQuery<GetStrojevi, dynamic>(selector.RawSql, parameters);

            return strojeviDelete;

        }
    }

