using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnketMerkezi.UI.Models.VMs.User
{
    public class LoginVM
    {
        [Required,MaxLength(25)]
        public string Username { get; set; }
        [Required, MaxLength(25)]
        public string Password { get; set; }
    }
}
