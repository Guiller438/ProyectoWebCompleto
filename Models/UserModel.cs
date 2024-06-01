using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IW7PP.Models
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        
    }
}
