using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicas.Models
{
    public class MedicoPaciente
    {
       
        public int MedicoId{ get; set; }

        public int PacienteId { get; set; }

        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }

      
       
    }
}
