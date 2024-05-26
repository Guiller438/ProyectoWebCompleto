using System.ComponentModel.DataAnnotations;

namespace IW7PP.ViewModel
{
    public class RegistroVM
    {
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber {  get; set; }
    }
}
