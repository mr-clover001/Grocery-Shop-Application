using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GroceryShopApp.Repository.Entities
{

    public partial class UsersRegister
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Role { get; set; }

        public DateTime MemberSin { get; set; }

        [StringLength(100)]
        public string Password { get; set; }


    }
}
