using SpieltagManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LigaManagerManagement.Models;

namespace VereinManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VereineController : ControllerBase
    {
        private readonly SpieltagManagement.Api.Models.IVereinRepository VereinRepository;

        public VereineController(IVereinRepository VereinRepository)
        {
            this.VereinRepository = VereinRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetVereine()
        {
            try
            {
                return Ok(await VereinRepository.GetVereine());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Lesen der Daten aus der Datenbank");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Verein>> GetVerein(int id)
        {
            try
            {
                var result = await VereinRepository.GetVerein(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Lesen der Daten aus der Datenbank");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Verein>> CreateVerein(Verein Verein)
        {
            try
            {
                if (Verein == null)
                {
                    return BadRequest();
                }

               
                var createdVerein = await VereinRepository.AddVerein(Verein);

                return CreatedAtAction(nameof(GetVerein), new { id = createdVerein.Id },
                    createdVerein);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Lesen der Daten aus der Datenbank");
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Verein>> UpdateVerein(Verein Verein)
        {
            try
            {
                var VereinToUpdate = await VereinRepository.GetVerein(Verein.Id);

                if (VereinToUpdate == null)
                {
                    return NotFound($"Verein mi der Id = {Verein.Id} nicht gefunden");
                }

                return await VereinRepository.UpdateVerein(Verein);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Update der Daten");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Verein>> DeleteVerein(int id)
        {
            try
            {
                var VereinToDelete = await VereinRepository.GetVerein(id);

                if (VereinToDelete == null)
                {
                    return NotFound($"Verein mit der Id = {id} nicht gefunden");
                }

                return await VereinRepository.DeleteVerein(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Löschen der Daten");
            }
        }
    }
}
