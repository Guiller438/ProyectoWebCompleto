using System.ComponentModel.DataAnnotations;

namespace IW7PP.Models.ProsthesisM
{
    public class Liner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$")]
        [Display(Name = "Liner Name")]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$")]
        [Display(Name = "Liner Description")]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(2)]
        [MinLength(1)]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$")]
        public double Durability { get; set; }
    }
}
