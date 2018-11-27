using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnketMerkezi.UI.Models.VMs.User
{
    public class RegisterVM
    {
        [Required, MaxLength(25), MinLength(6)]
        public string Username { get; set; }
        [Required, MaxLength(25), MinLength(6)]
        public string Password { get; set; }
        [Required, MaxLength(50), RegularExpression(@"/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/")]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [Required, MaxLength(20)]
        public string Surname { get; set; }
        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
