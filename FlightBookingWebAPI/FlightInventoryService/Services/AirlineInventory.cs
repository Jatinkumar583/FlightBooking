using FlightInventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInventoryService.Services
{
    public class AirlineInventory : IAirlineInventory
    {
        FlightBookingContext _flightBookingContext;
        public AirlineInventory(FlightBookingContext flightBookingContext)
        {
            _flightBookingContext = flightBookingContext;
        }

        public int AddAirlineInventory(TblAirlineInventory tblAirlineInventory)
        {
            try
            {
                _flightBookingContext.TblAirlineInventories.Add(tblAirlineInventory);
                _flightBookingContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
           
        }

        public List<TblAirlineInventory> GetAirlineInventoryDetails()
        {
            return _flightBookingContext.TblAirlineInventories.ToList();
        }
        public int RegisterAirline(TblAirlineRegistration tblAirlineDetail)
        {
            try
            {
                _flightBookingContext.TblAirlineRegistrations.Add(tblAirlineDetail);
                _flightBookingContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            
        }
    }
}
