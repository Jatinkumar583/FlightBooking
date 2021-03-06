using System;
using System.Collections.Generic;

#nullable disable

namespace FlightInventoryService.Models
{
    public partial class TblAirlineInventory
    {
        public int InventoryId { get; set; }
        public int FlightNumber { get; set; }
        public string Airline { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string ScheduledDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int? TotalBussClassSeats { get; set; }
        public int? TicketCost { get; set; }
        public int? NumberOfRows { get; set; }
        public string Meal { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
