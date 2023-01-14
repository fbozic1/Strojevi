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

        #region Post
        /// <summary>
        /// Dodavanje kvarova
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 404)]

        public async Task<ActionResult<IEnumerable<GetKvarovi>>> Post([FromServices] IKvaroviData data, KvaroviPost post)
        {
            try
            {
                

                var kvarovi = await data.InsertKvarovi(post);
                return Ok(kvarovi);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
    }
}
