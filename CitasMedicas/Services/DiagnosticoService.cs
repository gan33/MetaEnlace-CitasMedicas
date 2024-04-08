using AutoMapper;
using CitasMedicas.Models;
using CitasMedicas.Models.DTOs;
using CitasMedicas.Repository.Interfaces;
using CitasMedicas.Services.Intefaces;

namespace CitasMedicas.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiagnosticoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DiagnosticoDTO> AddDiagnostico(DiagnosticoDTO diagnosticoDTO)
        {
            var diagnostico = _mapper.Map<Diagnostico>(diagnosticoDTO);
            await _unitOfWork.DiagnosticoRe.Add(diagnostico);
            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<DiagnosticoDTO>(diagnostico);
            return result;
        }

        public async Task<bool> DeleteDiagnostico(int id)
        {
            if (!await _unitOfWork.DiagnosticoRe.Delete(id))
            {
                return false;
            }
            await _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<DiagnosticoDTO> GetDiagnosticoById(int id)
        {
            var diagnostioco = await _unitOfWork.DiagnosticoRe.GetById(id);
            var result = _mapper.Map<DiagnosticoDTO>(diagnostioco);
            return result;
        }

        public async Task<IEnumerable<DiagnosticoDTO>> GetDiagnosticos()
        {
            var diagnosticos = await _unitOfWork.DiagnosticoRe.GetAll();
            var result = _mapper.Map<IEnumerable<DiagnosticoDTO>>(diagnosticos);
            return result;
        }

        public async Task<bool> UpdateDiagnostico(int id, DiagnosticoDTO diagnosticoDTO)
        {
            var diagnostico = await _unitOfWork.DiagnosticoRe.GetById(id);
            if (diagnostico == null)
            {
                return false;
            }

            _mapper.Map(diagnosticoDTO, diagnostico);
            await _unitOfWork.DiagnosticoRe.Update(diagnostico);
            await _unitOfWork.SaveChanges();
            return true;
        }
    }
}
