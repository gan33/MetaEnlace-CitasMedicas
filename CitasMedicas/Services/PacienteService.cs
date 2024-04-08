using AutoMapper;
using CitasMedicas.Models;
using CitasMedicas.Models.DTOs;
using CitasMedicas.Repository.Interfaces;
using CitasMedicas.Services.Intefaces;
using System.Drawing.Text;

namespace CitasMedicas.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PacienteService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PacienteDTO> AddPaciente(PacienteDTO pacienteDTO)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDTO);
            await _unitOfWork.PacienteRe.Add(paciente);
            await _unitOfWork.SaveChanges();
            var result = _mapper.Map<PacienteDTO>(paciente);
            return result;
        }

        public async Task<bool> DeletePaciente(int id)
        {
            if (!await _unitOfWork.PacienteRe.Delete(id))
            {
                return false;
            }
            await _unitOfWork.SaveChanges();
            return true;    
        }

        public async Task<IEnumerable<PacienteDTO>> GetPacientes()
        {
            var pacientes = await _unitOfWork.PacienteRe.GetAll();
            var result = _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);
            return result;
        }

        public async Task<PacienteDTO> GetPacienteById(int id)
        {
            var paciente = await _unitOfWork.PacienteRe.GetById(id);
            var result = _mapper.Map<PacienteDTO>(paciente);
            return result;
        }

        public async Task<bool> UpdatePaciente(int id, PacienteDTO pacienteDTO)
        {
            var paciente = await _unitOfWork.PacienteRe.GetById(pacienteDTO.Id);
            if(paciente == null)
            {
                return false;
            }
            _mapper.Map(pacienteDTO, paciente);
            await _unitOfWork.PacienteRe.Update(paciente);
            await _unitOfWork.SaveChanges();
            return true;
        }

        public async Task AddMedicoToList(int pacienteId, int medicoId)
        {
            var medico = await _unitOfWork.MedicoRe.GetById(medicoId);
            var paciente = await _unitOfWork.PacienteRe.GetById(pacienteId);

            paciente.Medicos.Add(medico);
            await _unitOfWork.PacienteRe.Update(paciente);
            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<MedicoDTO>> GetMedicosByPacienteId(int pacienteId)
        {
          
            var paciente = await _unitOfWork.PacienteRe.GetById(pacienteId);
            if (paciente == null)
            {
               throw new Exception("Error. Paciente no encontrado.");
            }


            var medicos = await _unitOfWork.MedicoRe.GetAll();
            var medicos_filtrados = medicos.Where(p => p.Pacientes.Any(m => m.Id == pacienteId));
            var result = _mapper.Map<IEnumerable<MedicoDTO>>(medicos_filtrados);
            return  result;
        }

        public async Task<IEnumerable<CitaDTO>> GetCitasByPacienteId(int pacienteId)
        {

            var paciente = await _unitOfWork.PacienteRe.GetById(pacienteId);
            if (paciente == null)
            {
                throw new Exception("Error. Paciente no encontrado.");
            }

            var citas = await _unitOfWork.CitaRe.GetAll();
            var citas_filtradas = citas.Where(c => c.PacienteId == pacienteId);

            var result = _mapper.Map<IEnumerable<CitaDTO>>(citas_filtradas);
            return result;

        }
    }
}
