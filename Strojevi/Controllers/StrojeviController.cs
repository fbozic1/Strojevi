using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Strojevi.Data;
using Strojevi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Xml.Linq;


namespace Strojevi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class StrojeviController : ControllerBase
    {
        #region Get
        /// <summary>
        /// Dohvati strojeve
        /// </summary>
         [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromServices] IConfiguration config, int id)
        {
            using IDbConnection connection = new NpgsqlConnection(config.GetConnectionString("Default"));

            var strojeviDictionary = new Dictionary<int, GetStrojevi>();

            string sql = "SELECT strojevi.strojeviid,strojevi.naziv,kvarovi.kvaroviid, kvarovi.nazivkvara, kvarovi.prioritet,  kvarovi.opiskvara, kvarovi.statuskvara,  AVG(DATE_PART('day', kvarovi.datumzavrsetka::timestamp - kvarovi.datumpocetka::timestamp)) as ProsjecnoTrajanjeKvarova " +
                "FROM kvarovi INNER JOIN strojevi ON strojevi.naziv = kvarovi.nazivstroja WHERE (strojevi.strojeviid = @id OR @id = 0)  " +
                " GROUP BY strojevi.strojeviid,  strojevi.naziv, kvarovi.kvaroviid, kvarovi.nazivkvara,kvarovi.prioritet,  kvarovi.opiskvara, kvarovi.statuskvara,  kvarovi.datumpocetka";


            var list = connection.Query<GetStrojevi, KvaroviTest, GetStrojevi>(
                sql,
                (stroj, kvar) =>
                {
                    
                    GetStrojevi strojEntry;

                    if (!strojeviDictionary.TryGetValue(stroj.strojeviid, out strojEntry))
                    {
                        strojEntry = stroj;
                        strojEntry.Kvarovi = new List<KvaroviTest>();
                        strojeviDictionary.Add(strojEntry.strojeviid, strojEntry);
                    }
         
                    strojEntry.Kvarovi.Add(kvar);
                    return strojEntry;
                },
                new { id = id },
                splitOn: "kvaroviid")
            .Distinct()
            .ToList();

            

            return Ok(list);
        }
        #endregion

        #region Post
        /// <summary>
        /// Dodavanje strojeva
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetStrojevi>>> Post([FromServices] IStrojeviData data,StrojeviPost post)
        {
            try
            {
                if(post.naziv == "string")
                {
                    return BadRequest("Unesna vrijednost je nevažeća, unesite važeći naziv stroja");
                }

                var strojevi = await data.InsertStrojevi(post);
                return Ok(strojevi);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Put
        /// <summary>
        /// Ažuriranje strojeva
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetStrojevi>>> Put([FromServices] IStrojeviData data, StrojeviPut put)
        {
            try
            {
                if (put.naziv == "string")
                {
                    return BadRequest("Unesna vrijednost je nevažeća, unesite važeći naziv stroja");
                }

                var strojevi = await data.UpdateStrojevi(put);
                return Ok(strojevi);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Delete
        /// <summary>
        /// Brisanje strojeva
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetStrojevi>>> Delete([FromServices] IStrojeviData data, [FromQuery] int id)
        {
            try
            {
                var strojevi = await data.DeleteStrojevi(id);
                return Ok(strojevi);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

      
    }
}
