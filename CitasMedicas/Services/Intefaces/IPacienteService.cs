using CitasMedicas.Models.DTOs;

namespace CitasMedicas.Services.Intefaces
{
    public interface IPacienteService
    {

        Task<IEnumerable<PacienteDTO>> GetPacientes();
        Task<PacienteDTO> GetPacienteById(int id);
        Task<PacienteDTO> AddPaciente(PacienteDTO pacienteDTO);
        Task<bool> UpdatePaciente(int id,PacienteDTO pacienteDTO);
        Task<bool> DeletePaciente(int id);
        Task AddMedicoToList(int pacienteId, int medicoId);
        Task<IEnumerable<MedicoDTO>> GetMedicosByPacienteId(int pacienteId);
        Task<IEnumerable<CitaDTO>> GetCitasByPacienteId(int pacienteId);
    }
}
