using FlightBookService.Services;
using FlightBookService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookService.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;
        private readonly IUserRegistration _userRegistration;

        public UsersController(IJWTManagerRepository jWTManager, IUserRegistration userRegistration)
        {
            iJWTManager = jWTManager;
            _userRegistration = userRegistration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User userdata)
        {
            var token = iJWTManager.Authenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult UserRegistration(UserRegistDetails userdata)
        {
          _userRegistration.RegisterUser(userdata);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("getuserdetails")]
        public IActionResult GetUserDetails(User user)
        {
            if (user!=null)
            {
                return Ok(_userRegistration.GetUserDetails(user));
            }
            return BadRequest();
           
        }
    }
}
