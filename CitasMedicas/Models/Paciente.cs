using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicas.Models
{
    
    public class Paciente : Usuario
    {
        

        [Required(ErrorMessage = "Campo Obligatorio")]
        public required string NSS { get; set; }

        public string? NumTarjeta { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        
        public virtual ICollection<Medico> Medicos { get; set; }
     



        public virtual ICollection<Cita>? ListaCitasPaciente { get; set; }

        public Paciente() 
        {
            Medicos = new List<Medico>();   
        }   

    }

}
