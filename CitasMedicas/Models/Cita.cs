using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicas.Models
{

    
    public class Cita
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? FechaHora { get; set; }

        public string? MotivoCita { get; set; }

        public int Attribute11 { get; set; }
        public int PacienteId { get; set; }

        public int MedicoId { get; set; }

        public virtual  Paciente? Paciente { get; set; }

        public virtual Medico? Medico { get; set; }

        public virtual Diagnostico? Diagnostico { get; set; }

    }
}
