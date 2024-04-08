using CitasMedicas.Models;
using CitasMedicas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CitasMedicasContext _context;
        
        public UnitOfWork(CitasMedicasContext context)
        {
            this._context = context;
            MedicoRe = new MedicoRepository(this._context);
            PacienteRe = new PacienteRepository(this._context);
            CitaRe = new CitaRepository(this._context);
            DiagnosticoRe = new DiagnosticoRepository(this._context);
            
        }
        public IMedicoRepository MedicoRe { get; }

        public IPacienteRepository PacienteRe { get; }

        public ICitaRepository CitaRe { get; }

        public IDiagnosticoRepository DiagnosticoRe { get; }

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();
    }
}
