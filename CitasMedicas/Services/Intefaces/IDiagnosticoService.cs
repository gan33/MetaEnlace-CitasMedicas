using CitasMedicas.Models.DTOs;

namespace CitasMedicas.Services.Intefaces
{
    public interface IDiagnosticoService
    {
        Task<IEnumerable<DiagnosticoDTO>> GetDiagnosticos();
        Task<DiagnosticoDTO> GetDiagnosticoById(int id);
        Task<DiagnosticoDTO> AddDiagnostico(DiagnosticoDTO diagnosticoDTO);
        Task<bool> UpdateDiagnostico(int id, DiagnosticoDTO diagnosticoDTO);
        Task<bool> DeleteDiagnostico(int id);
    }
}
