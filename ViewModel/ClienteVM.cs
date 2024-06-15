using IW7PP.Models.Cliente;
using IW7PP.Models.ProsthesisM;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IW7PP.ViewModel
{
    public class ClienteVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        // Conexion con protesis
        public int? ProtesisId { get; set; }

        // Conexion con estilo de vida
        public int LifeStyleId { get; set; }

        // Navegación
    }
}
