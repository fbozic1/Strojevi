using Microsoft.AspNetCore.Mvc;
using Strojevi.Data;
using Strojevi.Models;
using System.Net;

namespace Strojevi.Controllers
{
   
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class KvaroviController : ControllerBase
    {
        #region Get
        /// <summary>
        /// Dohvati kvarove
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetKvarovi>>> Get([FromServices] IKvaroviData data, [FromQuery] int? id, [FromQuery] string? imestroja)
        {
            var kvarovi = await data.GetKvarovi(id, imestroja);
            return Ok(kvarovi);
        }
        #endregion

        #region Paginacija
        /// <summary>
        /// Paginacija
        /// </summary>
        [HttpGet]
        [Route("paginacija")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetKvarovi>>> OdredenBrojKvarova([FromServices] IKvaroviData data, int offset, int rows)
        {
            try
            {


                var kvaroviPaginacija = await data.OdredeniBrojKvarova(offset, rows);
                return Ok(kvaroviPaginacija);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Post
        /// <summary>
        /// Dodavanje kvarova
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetKvarovi>>> Post([FromServices] IKvaroviData data, KvaroviPost post)
        {
            DateTime datumPocetka = post.datumpocetka;
            DateTime? datumZavrsetka = post.datumzavrsetka;

            if (datumZavrsetka < datumPocetka)
            {
                throw new Exception("Datum završetka ne može biti manji od datuma početka !");
            }

            try
            {
                

                var kvaroviInsert = await data.InsertKvarovi(post);
                return Ok(kvaroviInsert);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Put
        /// <summary>
        /// Ažuriranje kvarova
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetKvarovi>>> Put([FromServices] IKvaroviData data, KvaroviPut put)
        {
            try
            {
                

                var kvaroviUpdate = await data.UpdateKvarovi(put);
                return Ok(kvaroviUpdate);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Put status kvara
        /// <summary>
        /// Ažuriranje statusa kvara
        /// </summary>
        [HttpPut]
        [Route("statuskvara")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetKvarovi>>> PutStatusKvara([FromServices] IKvaroviData data, int id, string statusKvara)
        {
            try
            {


                var kvaroviUpdateStatusa = await data.UpdateStatusa(statusKvara,id);
                return Ok(kvaroviUpdateStatusa);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Delete
        /// <summary>
        /// Brisanje kvarova
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetKvarovi>>> Delete([FromServices] IKvaroviData data, [FromQuery] int id)
        {
            try
            {
                var kvaroviDelete = await data.DeleteKvarovi(id);
                return Ok(kvaroviDelete);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
    }
}
