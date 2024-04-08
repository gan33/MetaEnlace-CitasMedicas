namespace CitasMedicas.Models.DTOs
{
    public class DiagnosticoDTO
    {
        public int Id { get; set; }
        public string ValoracionEspecialista { get; set; }
        public string Enfermedad { get; set; }
        public int CitaId { get; set; }
    }
}
