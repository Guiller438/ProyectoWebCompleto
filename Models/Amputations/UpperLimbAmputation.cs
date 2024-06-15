using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IW7PP.Models.Amputations
{
    public class UpperLimbAmputation 
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string? AmputationName { get; set; }
    }
}