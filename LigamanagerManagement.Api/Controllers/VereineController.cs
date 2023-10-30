using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpieltagManagement.Api.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

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

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Verein>> GetVerein(int Id)
        {
            try
            {
                var result = await VereinRepository.GetVerein(Id);

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
                    return NotFound($"Verein mit der Id = {VereinToUpdate.Id} nicht gefunden");
                }
                
                return await VereinRepository.UpdateVerein(Verein);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Update der Daten");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Verein>> DeleteVerein(int Id)
        {
            try
            {
                var VereinToDelete = await VereinRepository.GetVerein(Id);

                if (VereinToDelete == null)
                {
                    return NotFound($"Verein mit der Id = {Id} nicht gefunden");
                }

                return await VereinRepository.DeleteVerein(Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Löschen der Daten");
            }
        }
    }
}
