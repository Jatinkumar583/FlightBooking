using FlightSearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchService.Services
{
    public class FlightSearchDetails : IFlightSearchDetails
    {
        FlightBookingContext _flightBookingContext;
        public FlightSearchDetails(FlightBookingContext flightBookingContext)
        {
            _flightBookingContext = flightBookingContext;
        }
        public List<TblBookingDetail> GetFlightDetailsByPNR(string pnr)
        {
          return _flightBookingContext.TblBookingDetails.Where(x => x.Pnr == pnr).ToList();
        }
    }
}
