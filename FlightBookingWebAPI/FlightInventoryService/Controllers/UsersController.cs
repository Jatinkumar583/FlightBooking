using FlightInventoryService.Services;
using FlightInventoryService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInventoryService.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;

        public UsersController(IJWTManagerRepository jWTManager)
        {
            iJWTManager = jWTManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("inventory/authenticate")]
        public IActionResult Authenticate(User userdata)
        {
            var token = iJWTManager.Authenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
