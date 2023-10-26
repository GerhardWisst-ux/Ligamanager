using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpieltagManagement.Api.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LigaManagerManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpieltageController : ControllerBase
    {
        private readonly SpieltagManagement.Api.Models.ISpieltagRepository SpieltagRepository;

        public SpieltageController(ISpieltagRepository SpieltagRepository)
        {
            this.SpieltagRepository = SpieltagRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetSpieltage()
        {
            try
            {
                return Ok(await SpieltagRepository.GetSpieltage());
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Lesen der Daten aus der Datenbank");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Spieltag>> GetSpieltag(int id)
        {
            try
            {
                var result = await SpieltagRepository.GetSpieltag(id);

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
        public async Task<ActionResult<Spieltag>> CreateSpieltag(Spieltag spieltag)
        {
            try
            {
                if (spieltag == null)
                {
                    return BadRequest();
                }

               
                var createdSpieltag = await SpieltagRepository.AddSpieltag(spieltag);

                return CreatedAtAction(nameof(GetSpieltag), new { id = createdSpieltag.SpieltagId },
                    createdSpieltag);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Lesen der Daten aus der Datenbank");
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Spieltag>> UpdateSpieltag(Spieltag spieltag)
        {
            try
            {
                var employeeToUpdate = await SpieltagRepository.GetSpieltag(spieltag.SpieltagId);

                if (employeeToUpdate == null)
                {
                    return NotFound($"Spieltag mi der Id = {spieltag.SpieltagId} nicht gefunden");
                }

                return await SpieltagRepository.UpdateSpieltag(spieltag);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Update der Daten");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Spieltag>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await SpieltagRepository.GetSpieltag(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Spieltag mit der Id = {id} nicht gefunden");
                }

                return await SpieltagRepository.DeleteSpieltag(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim Löschen der Daten");
            }
        }
    }
}
