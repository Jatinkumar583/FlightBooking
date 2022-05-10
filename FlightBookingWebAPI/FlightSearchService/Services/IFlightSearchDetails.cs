using FlightSearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchService.Services
{
    public interface IFlightSearchDetails
    {
        List<TblBookingDetail> GetFlightDetailsByPNR(string pnr);
    }
}
