using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Business_Logic_Layer.ModelsDTO;
using Microsoft.AspNetCore.Authorization;

namespace GroceryShop.API.Controllers
{
    
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration config;
        private Business_Logic_Layer.UsersRegisterBLL _BLL;

        public UserController(IConfiguration _config)
        {
            config = _config;
            _BLL = new Business_Logic_Layer.UsersRegisterBLL();
        }


        [Route("ViewUsers")]
        [HttpGet]
        public List<UsersRegisterDTO> GetUsersRegister()
        {
            return _BLL.GetUsersRegister();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult AddUsersRegister([FromBody] UsersRegisterDTO usersRegisterM)
        {


            bool isExist = _BLL.AddUsersRegister(usersRegisterM);

            if (isExist)
            {
                return Ok("Already Exist");
            }
            else
            {
                return Ok("Success");
            }

            
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLoginM)
        {
            
            var userLoginAvailable = _BLL.UserLoggedIn(userLoginM);
            if (userLoginAvailable != null)
            {
                return Ok(new JwtService(config).GenerateToken(
                    userLoginAvailable.UserId.ToString(),
                    userLoginAvailable.FirstName,
                    userLoginAvailable.Email,
                    userLoginAvailable.Role
                    )
                    );
            }
            else
            {
                return Ok("Failure");
            }
        } 

    }
}
