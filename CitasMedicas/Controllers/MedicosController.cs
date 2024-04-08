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

namespace CitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicosController(IMedicoService medicoService)
        {
           _medicoService = medicoService;
        }

        // GET: api/Medicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoDTO>>> GetMedicos()
        {

            var medicos = await _medicoService.GetMedicos();
            return Ok(medicos);
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoDTO>> GetMedico(int id)
        {
            var medico = await _medicoService.GetMedicoById(id);

            if (medico == null)
            {
                return NotFound("Médico con ID " + id + " no encontrado.");
            }

            return Ok(medico);
        }

        // PUT: api/Medicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico(int id, MedicoDTO medicoDTO)
        {
          var exist =  await _medicoService.UpdateMedico(id, medicoDTO);
            if(!exist)
            {
                return NotFound("Médico con ID " + id + " no encontrado.");
            }
            return NoContent(); 
        }

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicoDTO>> PostMedico(MedicoDTO medicoDTO)
        {
            var medico = await _medicoService.AddMedico(medicoDTO);
            return CreatedAtAction(nameof(GetMedico), new { id = medico.Id }, medico);
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
          var exist = await _medicoService.DeleteMedico(id);
            if(!exist)
            {
                return NotFound("Médico con ID " + id + " no encontrado.");
            }
            return NoContent();
        }

        [HttpPost("{medicoId}/pacientes")]
        public async Task<IActionResult> AddPacienteToList(int medicoId, [FromBody] int pacienteId)
        {
            await _medicoService.AddPacienteToList(medicoId, pacienteId);
            return NoContent();
        }

        [HttpGet("{medicoId}/pacientes")]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetPacientesByMedicoId(int medicoId)
        {
            try
            {
                var pacientes = await _medicoService.GetPacientesByMedicoId(medicoId);
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
            
        }

        [HttpGet("{medicoId}/citas")]
        public async Task<ActionResult<IEnumerable<CitaDTO>>> GetCitasByMedicoId(int medicoId)
        {
            try
            {
                var citas = await _medicoService.GetCitasByMedicoId(medicoId);
                return Ok(citas);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
