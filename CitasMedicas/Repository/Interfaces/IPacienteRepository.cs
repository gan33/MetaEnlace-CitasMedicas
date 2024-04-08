using CitasMedicas.Models;

namespace CitasMedicas.Repository.Interfaces
{
    public interface IPacienteRepository
    {

        Task<Paciente> GetById(int id);
        Task<IEnumerable<Paciente>> GetAll();
        Task<Paciente> Add(Paciente paciente);
        Task<bool> Delete(int id);
        Task<Paciente> Update(Paciente paciente);

       
       
    }
}
