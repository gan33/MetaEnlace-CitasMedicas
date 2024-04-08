using CitasMedicas.Models;

namespace CitasMedicas.Repository.Interfaces
{
    public interface IMedicoRepository
    {
        Task<Medico> GetById(int id);
        Task<IEnumerable<Medico>> GetAll();
        Task<Medico> Add(Medico medico);
        Task<bool> Delete(int id);
        Task<Medico?> Update(Medico medico);
       
      
    }
}
