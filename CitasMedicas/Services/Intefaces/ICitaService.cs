using CitasMedicas.Models.DTOs;

namespace CitasMedicas.Services.Intefaces
{
    public interface ICitaService
    {

        Task<IEnumerable<CitaDTO>> GetAll();
        Task<CitaDTO> GetById(int id);
        Task<CreateCitaDTO> AddCita(CreateCitaDTO citaDTO);
        Task<bool> UpdateCita(int id, CreateCitaDTO citaDTO);
        Task<bool> DeleteCita(int id);
    }
}
