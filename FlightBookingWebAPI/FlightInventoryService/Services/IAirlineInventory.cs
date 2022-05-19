using FlightInventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInventoryService.Services
{
    public interface IAirlineInventory
    {
        List<TblAirlineInventory> GetAirlineInventoryDetails();
        int RegisterAirline(TblAirlineRegistration tblAirlineDetail);
        int AddAirlineInventory(TblAirlineInventory tblAirlineInventory);

        int UpdateFlightInventory(TblAirlineInventory tblAirlineInventory);
    }
}
