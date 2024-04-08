using CitasMedicas.Models;
using CitasMedicas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        public readonly CitasMedicasContext _context;

        public PacienteRepository(CitasMedicasContext context)
        {
            this._context = context;
        }

        public async Task<Paciente> GetById(int id)
        {
            try
            {
                return await _context.Set<Paciente>().Include(p => p.Medicos)  //Incluye la información de la tabla a la que hace referencia.
                          .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo obtener el paciente", ex);
            }
        }

        public async Task<IEnumerable<Paciente>> GetAll()
        {
            try
            {
                return await _context.Set<Paciente>().Include(p => p.Medicos)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo obtener la colección de pacientes", ex);
            }
        }

        public async Task<Paciente> Add(Paciente paciente)
        {
            try
            {
                _context.Set<Paciente>().Add(paciente);
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo añadir el paciente", ex);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var paciente = await _context.Set<Paciente>().FindAsync(id);
                if (paciente == null)
                {
                    return false;
                }
                   

                _context.Set<Paciente>().Remove(paciente);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo eliminar el paciente", ex);
            }
        }

        public async Task<Paciente> Update(Paciente paciente)
        {
            try
            {
                _context.Entry(paciente).State = EntityState.Modified;
                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo actualizar el paciente", ex);
            }
        }

     
    }
}
