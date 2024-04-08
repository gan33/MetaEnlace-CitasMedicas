using AutoMapper;
using CitasMedicas.Models;
using CitasMedicas.Models.DTOs;

namespace CitasMedicas.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(e => e.Id, o => o.MapFrom(d => d.Id))
                .ForMember(e => e.Nombre, o => o.MapFrom(d => d.Nombre))
                .ForMember(e => e.Apellidos, o => o.MapFrom(d => d.Apellidos))
                .ForMember(e => e.NombreUsuario, o => o.MapFrom(d => d.NombreUsuario))
                .ForMember(e => e.Clave, o => o.MapFrom(d => d.Clave));

            CreateMap<Medico, MedicoDTO>();
            CreateMap<MedicoDTO, Medico>()
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.NumColegiado, o => o.MapFrom(d => d.NumColegiado));

            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTO, Paciente>()
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.NumTarjeta, o => o.MapFrom(d => d.NumTarjeta))
                .ForMember(e => e.NSS, o => o.MapFrom(d => d.NSS))
                .ForMember(e => e.Telefono, o => o.MapFrom(d => d.Telefono))
                .ForMember(e => e.Direccion, o => o.MapFrom(d => d.Direccion));


            CreateMap<Cita, CitaDTO>();
            CreateMap<CitaDTO, Cita>()
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.MotivoCita, o => o.MapFrom(d => d.MotivoCita))
                .ForMember(e => e.Attribute11, o => o.MapFrom(d => d.Attribute11));
            CreateMap<Cita, CreateCitaDTO>();
            CreateMap<CreateCitaDTO, Cita>()
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.MotivoCita, o => o.MapFrom(d => d.MotivoCita))
                .ForMember(e => e.Attribute11, o => o.MapFrom(d => d.Attribute11))
                .ForMember(e => e.MedicoId, o => o.MapFrom(d => d.MedicoId))
                .ForMember(e => e.PacienteId, o => o.MapFrom(d => d.PacienteId));

            CreateMap<Diagnostico, DiagnosticoDTO>();
            CreateMap<DiagnosticoDTO, Diagnostico>()
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.Enfermedad, o => o.MapFrom(d => d.Enfermedad))
                .ForMember(e => e.ValoracionEspecialista, o => o.MapFrom(d => d.ValoracionEspecialista))
                .ForMember(e => e.CitaId, o => o.MapFrom(d => d.CitaId));


        }


    }
}
