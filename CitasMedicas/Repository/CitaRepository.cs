using CitasMedicas.Models;
using CitasMedicas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Repository
{
    public class CitaRepository : ICitaRepository
    {
        public readonly CitasMedicasContext _context;

        public CitaRepository(CitasMedicasContext context)
        {
            _context = context;
        }

        public async Task<Cita> Get(int id)
        {
            try
            {
                return await _context.Set<Cita>().Include(m => m.Medico).Include(p => p.Paciente).Include(d => d.Diagnostico).FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo encontrar la cita.", ex);
            }
        }

        public async Task<IEnumerable<Cita>> GetAll()
        {
            try
            {
                return await _context.Set<Cita>().Include(m => m.Medico).Include(p => p.Paciente).Include(d => d.Diagnostico).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo encontrar la colección de citas.", ex);
            }
           
        }


       

        public async Task<Cita> Add(Cita cita)
        {
            try
            {
                if (!await _context.Medicos.AnyAsync(m => m.Id == cita.MedicoId))
                {
                    throw new Exception("El médico con el ID especificado no existe.");
                }

                if (!await _context.Pacientes.AnyAsync(m => m.Id == cita.PacienteId))
                {
                    throw new Exception("El paciente con el ID especificado no existe.");
                }


                _context.Set<Cita>().Add(cita);
                await _context.SaveChangesAsync();
                return cita;

            } catch (Exception ex)
            {
                throw new Exception("Error. No se pudo añadir la cita.", ex);
            }
            
        }

        public async Task<Cita> Update(Cita cita)
        {
            try
            {
                if (!await _context.Medicos.AnyAsync(m => m.Id == cita.MedicoId))
                {
                    throw new Exception("El médico con el ID especificado no existe.");
                }

                if (!await _context.Pacientes.AnyAsync(m => m.Id == cita.PacienteId))
                {
                    throw new Exception("El paciente con el ID especificado no existe.");
                }

                _context.Entry(cita).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return cita;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo actualizar la cita.", ex);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var cita = await _context.Set<Cita>().FindAsync(id);
                if (cita == null)
                {
                    return false;
                }
                    
                _context.Set<Cita>().Remove(cita);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo borrar la cita.", ex);
            }
        }
    }
}
