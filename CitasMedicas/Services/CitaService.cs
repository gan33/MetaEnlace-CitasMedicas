using AutoMapper;
using CitasMedicas.Models.DTOs;
using CitasMedicas.Models;
using CitasMedicas.Repository.Interfaces;
using CitasMedicas.Services.Intefaces;

namespace CitasMedicas.Services
{
    public class CitaService : ICitaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CitaService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateCitaDTO> AddCita(CreateCitaDTO citaDTO)
        {
            var cita = _mapper.Map<Cita>(citaDTO);
            await _unitOfWork.CitaRe.Add(cita);
            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<CreateCitaDTO>(cita);
            return result;
        }

        public async Task<CitaDTO> GetById(int id)
        {


            var cita = await _unitOfWork.CitaRe.Get(id);
            var result = _mapper.Map<CitaDTO>(cita);
            return result;
        }

        public async Task<IEnumerable<CitaDTO>> GetAll()
        {
            var citas = await _unitOfWork.CitaRe.GetAll();
            var result = _mapper.Map<IEnumerable<CitaDTO>>(citas);
            return result;
        }

        public async Task<bool> DeleteCita(int id)
        {
            if(!await _unitOfWork.CitaRe.Delete(id))
            {
                return false;
            }
            await _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateCita(int id, CreateCitaDTO citaDTO)
        {
            var cita = await _unitOfWork.CitaRe.Get(id);
            if (cita == null)
            {
                return false;
            }
            _mapper.Map(citaDTO, cita);
            await _unitOfWork.CitaRe.Update(cita);
            await _unitOfWork.SaveChanges();
            return true;
        }

        
    }
}
