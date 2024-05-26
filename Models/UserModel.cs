using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IW7PP.Models
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }


        
    }
}
