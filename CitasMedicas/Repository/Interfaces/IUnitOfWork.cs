using CitasMedicas.Models;

namespace CitasMedicas.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IMedicoRepository MedicoRe{ get; }
        IPacienteRepository PacienteRe { get; }
        ICitaRepository CitaRe { get; }
        IDiagnosticoRepository DiagnosticoRe { get; }
        Task<int> SaveChanges ();
    }
}
