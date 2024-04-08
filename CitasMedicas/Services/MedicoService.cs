using AutoMapper;
using CitasMedicas.Models;
using CitasMedicas.Models.DTOs;
using CitasMedicas.Repository.Interfaces;
using CitasMedicas.Services.Intefaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

namespace CitasMedicas.Services
{
    public class MedicoService : IMedicoService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MedicoDTO> AddMedico(MedicoDTO medicoDTO)
        {
            var medico = _mapper.Map<Medico>(medicoDTO);
            await _unitOfWork.MedicoRe.Add(medico);
            await _unitOfWork.SaveChanges();

            var result =  _mapper.Map<MedicoDTO>(medico);
            return result;
        }

        public async Task<bool> DeleteMedico(int id)
        {
            if(!await _unitOfWork.MedicoRe.Delete(id))
            {
                return false;
            }
            await _unitOfWork.SaveChanges();
            return true;
     
        }
    

        public async Task<MedicoDTO> GetMedicoById(int id)
        {


            var medico = await _unitOfWork.MedicoRe.GetById(id);
            var result = _mapper.Map<MedicoDTO>(medico);
            return result;
        }

        public async Task<IEnumerable<MedicoDTO>> GetMedicos()
        {
            var medicos = await _unitOfWork.MedicoRe.GetAll();
            var result =  _mapper.Map<IEnumerable<MedicoDTO>>(medicos);
            return result;
        }

        public async Task<bool> UpdateMedico(int id, MedicoDTO medicoDTO)
        {
            var medico = await _unitOfWork.MedicoRe.GetById(id);
            if (medico == null)
            {
                return false;
            }

            _mapper.Map(medicoDTO, medico);
            await _unitOfWork.MedicoRe.Update(medico);
            await _unitOfWork.SaveChanges();
            return true;
        }

        public async Task AddPacienteToList(int medicoId, int pacienteId)
        {
            var medico = await _unitOfWork.MedicoRe.GetById(medicoId);
            var paciente = await _unitOfWork.PacienteRe.GetById(pacienteId);
            if (medico == null)
            {

                throw new Exception("Error. Médico no encontrado");
            }

            medico.Pacientes.Add(paciente);
            await _unitOfWork.MedicoRe.Update(medico);
            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<PacienteDTO>> GetPacientesByMedicoId(int medicoId)
        {

            var medico = await _unitOfWork.MedicoRe.GetById(medicoId);
            if(medico == null)
            {
                throw new Exception("Error. Médico no encontrado.");
            }
            

            var pacientes = await _unitOfWork.PacienteRe.GetAll();
            var pacientes_filtrados = pacientes.Where(m => m.Medicos.Any(mp => mp.Id == medicoId));
            
            var result = _mapper.Map<IEnumerable<PacienteDTO>>(pacientes_filtrados);
            return result;



        }

        public async Task<IEnumerable<CitaDTO>> GetCitasByMedicoId(int medicoId)
        {

            var medico = await _unitOfWork.MedicoRe.GetById(medicoId);
            if(medico == null)
            {
                throw new Exception("Error. Médico no encontrado.");
            }

            var citas = await _unitOfWork.CitaRe.GetAll();
            var citas_filtradas = citas.Where(c => c.MedicoId == medicoId);

            var result = _mapper.Map<IEnumerable<CitaDTO>>(citas_filtradas);
            return result;

        }
    }
}
