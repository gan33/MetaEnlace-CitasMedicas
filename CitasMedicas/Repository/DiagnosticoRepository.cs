using CitasMedicas.Models;
using CitasMedicas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Repository
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {

        public readonly CitasMedicasContext _context;

        public DiagnosticoRepository(CitasMedicasContext context)
        {
            this._context = context;
        }

        public async Task<Diagnostico> GetById(int id)
        {
            try
            {
                return await _context.Set<Diagnostico>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo encontrar el diagnóstico.", ex);
            }
        }

        public async Task<Diagnostico> Add(Diagnostico diagnostico)
        {
            try
            {
                if (!await _context.Citas.AnyAsync(m => m.Id == diagnostico.CitaId))
                {
                    throw new Exception("La cita con el ID especificado no existe.");
                }

                if(await _context.Diagnosticos.AnyAsync(d => d.CitaId == diagnostico.CitaId))
                {
                    throw new Exception("La cita ya contiene un diagnóstico.");
                }

                
                _context.Set<Diagnostico>().Add(diagnostico);
                return diagnostico;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo añadir el diagnóstico.", ex);
            }
        }

        public async Task<Diagnostico> Update(Diagnostico diagnostico)
        {
            try
            {
                if (!await _context.Citas.AnyAsync(m => m.Id == diagnostico.CitaId))
                {
                    throw new Exception("La cita con el ID especificado no existe.");
                } 

                _context.Entry(diagnostico).State = EntityState.Modified;
                return diagnostico;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo actualizar el diagnóstico.", ex);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var diagnostico = await _context.Set<Diagnostico>().FindAsync(id);
                if (diagnostico == null)
                {
                    return false;
                }

                _context.Set<Diagnostico>().Remove(diagnostico);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo borrar el diagnóstico.", ex);
            }
        }

        public async Task<IEnumerable<Diagnostico>> GetAll()
        {
            try
            {
                return await _context.Set<Diagnostico>().ToListAsync();

            }catch (Exception ex)
            {
                throw new Exception("Error. No se pudieron obtener los diagnósticos.");
            }
        }
    }
}
