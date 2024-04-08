namespace CitasMedicas.Models.DTOs
{
    public class CreateCitaDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }

        public int Attribute11 { get; set; }

        public int MedicoId { get; set; }
        public int PacienteId { get; set; }

    }
}
