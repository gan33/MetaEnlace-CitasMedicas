namespace CitasMedicas.Models.DTOs
{
    public class CitaDTO
    {
       public int Id { get; set; }  
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }

        public int Attribute11 { get; set; }
      
        public MedicoDTO Medico { get; set; }
        public PacienteDTO Paciente { get; set; }

        public DiagnosticoDTO Diagnostico { get; set; }

        
    }
}
