using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.ModelsDTO
{
   public class UsersRegisterDTO
    {



   
        public int UserId { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

 
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Role { get; set; }

        public DateTime MemberSin { get; set; }

        public string Password { get; set; }
    }
}
