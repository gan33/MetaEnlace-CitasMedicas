using CitasMedicas.Models;

namespace CitasMedicas.Repository.Interfaces
{
    public interface ICitaRepository
    {
        Task<Cita> Get(int id);
        Task<IEnumerable<Cita>> GetAll();
        Task<Cita> Add(Cita cita);
        Task<Cita> Update(Cita cita);
        Task<bool> Delete(int id);
    }
}
