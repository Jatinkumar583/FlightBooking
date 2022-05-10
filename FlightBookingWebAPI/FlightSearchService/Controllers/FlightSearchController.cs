using FlightSearchService.Models;
using FlightSearchService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchService.Controllers
{
    [Authorize]
    [Route("api/v1.0/flight")]
    [ApiController]
    public class FlightSearchController : ControllerBase
    {
        IFlightSearchDetails _flightSearchDetails;
        public FlightSearchController(IFlightSearchDetails flightSearchDetails)
        {
            _flightSearchDetails = flightSearchDetails;
        }

        [HttpGet("ticket/{pnr}")]
        public IActionResult GetBookedFlightDetailsByPNR(string pnr)
        {
            try
            {
                return Ok(_flightSearchDetails.GetFlightDetailsByPNR(pnr));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
