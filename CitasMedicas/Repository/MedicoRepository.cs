using CitasMedicas.Models;
using CitasMedicas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CitasMedicas.Repository
{
    public class MedicoRepository : IMedicoRepository
    {

        public readonly CitasMedicasContext _context;

        public MedicoRepository(CitasMedicasContext context)
        {
            this._context = context;
        }

        public async Task<Medico> GetById(int id)
        {
            try
            {
                return await _context.Set<Medico>().Include(p => p.Pacientes)
                          .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. Médico por Id no encontrado.", ex);
            }
        }

        public async Task<IEnumerable<Medico>> GetAll()
        {
            try
            {
                return await _context.Set<Medico>().Include(p => p.Pacientes).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo obtener la colección de médicos.", ex);
            }
        }

     

        public async Task<Medico> Add(Medico medico)
        {
            try
            {
               _context.Set<Medico>().Add(medico);
                
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo agregar médico. ", ex);
            }

        }

        public async Task<bool> Delete(int id)
        {
            try{
                var medico = await _context.Set<Medico>().FindAsync(id);
                if (medico == null)
                {
                    return false;
                }
                    

                _context.Set<Medico>().Remove(medico);
                return true;
            }
            catch (Exception ex){
                throw new Exception("Error. No se pudo eliminar el médico", ex);
            }
        }

        public async Task<Medico?> Update(Medico medico)
        {
            try
            {
                var _medico = await _context.Set<Medico>().FindAsync(medico.Id);
                if (_medico == null)
                {
                    return null;
                }    
                _context.Entry(medico).State = EntityState.Modified;
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception("Error. No se pudo actualizar el médico", ex);
            }
        }

       

       
    }
}
