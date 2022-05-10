using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInventoryService.Events
{
    public class VedioCreatedEvent
    {
        public int FlightNumber { get; set; }
        public string Pnr { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public int? TotalSeat { get; set; }
    }
}
