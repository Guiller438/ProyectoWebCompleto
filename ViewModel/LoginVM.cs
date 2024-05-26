using System.ComponentModel.DataAnnotations;

namespace IW7PP.ViewModel
{
    public class LoginVM
    {
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string UserName { get; set; }    

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
