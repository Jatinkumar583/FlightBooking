//using FlightInventoryService.Services;
using FlightInventoryService.Models;
using FlightInventoryService.Services;
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
    [Route("api/v1.0/flight")]
    [ApiController]
    public class FlightInventoryController : ControllerBase
    {
        IAirlineInventory _airlineInventory;
        public FlightInventoryController(IAirlineInventory airlineInventory)
        {
            _airlineInventory = airlineInventory;
        }

        [HttpGet("airline/inventory/list")]
        public IActionResult FindAirlineInventory()
        {
            try
            {
                return Ok(_airlineInventory.GetAirlineInventoryDetails());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("airline/register")]
        public IActionResult RegisterNewAirline(TblAirlineRegistration airlineDetail)
        {
            try
            {
                if (airlineDetail != null)
                {
                    var registerStatus = _airlineInventory.RegisterAirline(airlineDetail);
                    if (registerStatus == 1)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("airline/inventory/add")]
        public IActionResult AddAirlineInventory(TblAirlineInventory inventoryDetails)
        {
            try
            {
                if (inventoryDetails != null)
                {
                    var addStatus = _airlineInventory.AddAirlineInventory(inventoryDetails);
                    if (addStatus == 1)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("airline/inventory/update")]
        public IActionResult UpdateAirlineInventory(TblAirlineInventory inventoryDetails)
        {
            try
            {
                if (inventoryDetails != null)
                {
                    var addStatus = _airlineInventory.UpdateFlightInventory(inventoryDetails);
                    if (addStatus == 1)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
