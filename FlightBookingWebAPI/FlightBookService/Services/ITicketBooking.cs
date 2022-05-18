using FlightBookService.Models;
using FlightBookService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookService.Services
{
    public interface ITicketBooking
    {
        List<TblBookingDetail> GetBookingDetailsByEmailId(string emailId);
        int BookFlight(BookingDetails tblBookingDetail);
        List<TblPassengerDetail> GetPassengerDetails(int bookingId);
        int CancelBookedTicketByPNR(string pnr);
    }
}
