using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Access_Layer.Repository.Entities
{
   public partial class UserLogin
    {
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }
    }
}
