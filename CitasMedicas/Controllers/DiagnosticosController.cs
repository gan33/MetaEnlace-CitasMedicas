using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CitasMedicas.Models;
using CitasMedicas.Services.Intefaces;
using CitasMedicas.Models.DTOs;
using CitasMedicas.Services;

namespace CitasMedicas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticosController : ControllerBase
    {
        private readonly IDiagnosticoService _diagnosticoService;

        public DiagnosticosController(IDiagnosticoService diagnosticoService)
        {
            _diagnosticoService = diagnosticoService;
        }

        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosticoDTO>>> GetDiagnosticos()
        {
            var diagnosticos = await _diagnosticoService.GetDiagnosticos();
            return Ok(diagnosticos);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<DiagnosticoDTO>> GetDiagnostico(int id)
        {
            var diagnostico = await _diagnosticoService.GetDiagnosticoById(id);

            if (diagnostico == null)
            {
                return NotFound("Diagnóstico con ID " + id + " no encontrado.");
            }

            return Ok(diagnostico);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnostico(int id, DiagnosticoDTO diagnosticoDTO)
        {
            var exist = await _diagnosticoService.UpdateDiagnostico(id, diagnosticoDTO);
            if (!exist)
            {
                return NotFound("Diagnóstico con ID " + id + " no encontrado.");
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DiagnosticoDTO>> PostDiagnostico(DiagnosticoDTO diagnosticoDTO)
        {
            var diagnostico = await _diagnosticoService.AddDiagnostico(diagnosticoDTO);
            return CreatedAtAction(nameof(GetDiagnostico), new { id = diagnostico.Id }, diagnostico);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnostico(int id)
        {
            var exist = await _diagnosticoService.DeleteDiagnostico(id);
            if (!exist)
            {
                return NotFound("Diagnóstico con ID " + id + " no encontrado.");
            }
            return NoContent();
        }


    }
}
