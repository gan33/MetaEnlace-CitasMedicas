using CitasMedicas.Models.DTOs;

namespace CitasMedicas.Services.Intefaces
{
    public interface IMedicoService
    {
            Task<IEnumerable<MedicoDTO>> GetMedicos();
            Task<MedicoDTO> GetMedicoById(int id);
            Task<MedicoDTO> AddMedico(MedicoDTO medicoDTO);
            Task<bool> UpdateMedico(int id,MedicoDTO medicoDTO);
            Task<bool> DeleteMedico(int id);
            Task AddPacienteToList(int medicoId, int pacienteId);
            Task<IEnumerable<PacienteDTO>> GetPacientesByMedicoId(int medicoId);
            Task<IEnumerable<CitaDTO>> GetCitasByMedicoId(int medicoId);
    }
}
