using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicas.Models
{


    public class Medico : Usuario
    {
        public string? NumColegiado { get; set; }

        
        public virtual ICollection<Paciente> Pacientes { get; set; }
       



        public virtual ICollection<Cita>? ListaCitasMedico { get; set; }

        Medico() 
        {
            Pacientes = new List<Paciente>();
        }


    }
}
