using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Models
{

   
    public abstract class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre {  get; set; }
        public string? Apellidos {  get; set; }
        public string? NombreUsuario { get; set; } 
        public string? Clave {  get; set; }

    }
}
