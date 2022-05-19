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

        public int UpdateFlightInventory(TblAirlineInventory tblAirlineInventory)
        {
            try
            {
                #region Update tblAirlineInventory table
                var entity = _flightBookingContext.TblAirlineInventories.FirstOrDefault(item => item.FlightNumber == tblAirlineInventory.FlightNumber);
                // Validate entity is not null
                if (entity != null)
                {
                    // Make changes on entity
                    entity.Airline = tblAirlineInventory.Airline;
                    entity.FromPlace = tblAirlineInventory.FromPlace;
                    entity.ToPlace = tblAirlineInventory.ToPlace;
                    entity.StartDateTime = tblAirlineInventory.StartDateTime;
                    entity.EndDateTime = tblAirlineInventory.EndDateTime;
                    entity.ScheduledDays = tblAirlineInventory.ScheduledDays;
                    entity.InstrumentUsed = tblAirlineInventory.InstrumentUsed;
                    entity.TotalBussClassSeats = tblAirlineInventory.TotalBussClassSeats;
                    entity.TicketCost = tblAirlineInventory.TicketCost;
                    entity.NumberOfRows = tblAirlineInventory.NumberOfRows;
                    entity.Meal = tblAirlineInventory.Meal;
                    // Save changes in database
                    _flightBookingContext.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

                #endregion
            }
            catch (Exception ex)
            {
                return 0;
            }
          
        }
    }
}
