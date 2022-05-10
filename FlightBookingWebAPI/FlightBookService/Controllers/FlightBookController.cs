//using FlightBookService.Services;
using FlightBookService.Models;
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
    [Route("api/v1.0/flight")]
    [ApiController]
    public class FlightBookController : ControllerBase
    {
        ITicketBooking _ticketBooking;
        public FlightBookController(ITicketBooking ticketBooking)
        {
            _ticketBooking = ticketBooking;
        }
        
        [HttpGet("booking/history/{emailId}")]
        public IActionResult GetBookedDetailsByEmailId(string emailId)
        {
            try
            {
                return Ok(_ticketBooking.GetBookingDetailsByEmailId(emailId));              
            }
            catch
            {
                return BadRequest();
            }
        }

       

        [HttpPost("booking/flightdetails")]
        public IActionResult BookFlight(BookingDetails bookingDetail)
        {
            try
            {
                if (bookingDetail != null)
                {
                   int bookStatus= _ticketBooking.BookFlight(bookingDetail);
                    if (bookStatus==1)
                    {
                        return Ok("Flight Booked Successfully.");
                    }
                    else
                    {
                        return BadRequest("Flight Not Booked.");
                    }
                }
                return BadRequest();
            }
            catch 
            {
                return BadRequest();
            }
           
        }

        [HttpDelete("booking/cancel/{pnr}")]
        public IActionResult CancelBookedTicketByPNR(string pnr)
        {
            try
            {
               int cancelStatus= _ticketBooking.CancelBookedTicketByPNR(pnr);
                if (cancelStatus==1)
                {
                    return Ok("Cancelled Record Successfully.");
                }
                else
                {
                    return BadRequest("Record Not Cancelled.");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

    }

}
