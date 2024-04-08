using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasMedicas.Models;
using CitasMedicas.Services.Intefaces;
using CitasMedicas.Models.DTOs;
using CitasMedicas.Services;

namespace CitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitasController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaDTO>>> GetCitas()
        {
            var citas = await _citaService.GetAll();
            return Ok(citas);
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = await _citaService.GetById(id);

            if (cita == null)
            {
                return NotFound("Error. Cita con Id " + id + " no encontrada." );
            }

            return Ok(cita);
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, CreateCitaDTO citaDTO)
        {
                var exist = await _citaService.UpdateCita(id, citaDTO);
                if (!exist)
                {
                    return NotFound("Cita con ID " + id + " no encontrada.");
                }
                return NoContent();
            
        }

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateCitaDTO>> PostCita(CreateCitaDTO citaDTO)
        {
            var cita = await _citaService.AddCita(citaDTO);
            return CreatedAtAction(nameof(GetCita), new { id = cita.Id }, cita);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {

            var exist = await _citaService.DeleteCita(id);
            if (!exist)
            {
                return NotFound("Cita con ID " + id + " no encontrada.");
            }
            return NoContent();

        }


    }
}
