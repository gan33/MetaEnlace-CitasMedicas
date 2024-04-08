using CitasMedicas.Models;

namespace CitasMedicas.Repository.Interfaces
{
    public interface IDiagnosticoRepository
    {
        Task<Diagnostico> GetById(int id);
        Task<IEnumerable<Diagnostico>> GetAll();
        Task<Diagnostico> Add(Diagnostico diagnostico);
        Task<Diagnostico> Update(Diagnostico diagnostico);
        Task<bool> Delete(int id);
       
       
    }
}
