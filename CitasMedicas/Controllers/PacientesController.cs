using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasMedicas.Models;
using CitasMedicas.Services.Intefaces;
using CitasMedicas.Services;
using CitasMedicas.Models.DTOs;

namespace CitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetPacientes()
        {
            var pacientes = await _pacienteService.GetPacientes();
            return Ok(pacientes);
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDTO>> GetPaciente(int id)
        {
            var paciente = await _pacienteService.GetPacienteById(id);

            if (paciente == null)
            {
                return NotFound("Paciente con ID " + id + " no encontrado.");
            }

            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteDTO pacienteDTO)
        {
            var exist = await _pacienteService.UpdatePaciente(id, pacienteDTO);
            if(!exist)
            {
                return NotFound("Paciente con ID " + id + " no encontrado.");
            }
            return NoContent();
        }

        // POST: api/Pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PacienteDTO>> PostPaciente(PacienteDTO pacienteDTO)
        {
            var paciente = await _pacienteService.AddPaciente(pacienteDTO); //400 lo hace por defecto.

            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.Id }, paciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var exist =  await _pacienteService.DeletePaciente(id);
            if (!exist)
            {
                return NotFound("Paciente con ID " + id + " no encontrado.");
            }
            return NoContent();
        }

         [HttpPost("{pacienteId}/medicos")]
        public async Task<IActionResult> AddMedicoToList(int pacienteId, [FromBody] int medicoId)
        {
            await _pacienteService.AddMedicoToList(pacienteId, medicoId);
            return NoContent();
        }

        [HttpGet("{pacienteId}/medicos")]
        public async Task<ActionResult<IEnumerable<MedicoDTO>>> GetPacientesByMedicoId(int pacienteId)
        {
            try
            {
                var medicosDTO = await _pacienteService.GetMedicosByPacienteId(pacienteId);
                return Ok(medicosDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{pacienteId}/citas")]
        public async Task<ActionResult<IEnumerable<CitaDTO>>> GetCitasByMedicoId(int pacienteId)
        {
            try
            {
                var citas = await _pacienteService.GetCitasByPacienteId(pacienteId);
                return Ok(citas);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        
    }
}
