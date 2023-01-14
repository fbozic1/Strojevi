using Microsoft.AspNetCore.Mvc;
using Strojevi.Data;
using Strojevi.Models;
using System.Net;


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
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetStrojevi>>> Get([FromServices] IStrojeviData data, [FromQuery] int? id, [FromQuery] string? naziv)
        {
            var strojevi = await data.GetStrojevi(id, naziv);
            return Ok(strojevi);
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
