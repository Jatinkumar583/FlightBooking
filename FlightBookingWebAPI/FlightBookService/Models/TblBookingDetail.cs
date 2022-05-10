using System;
using System.Collections.Generic;

#nullable disable

namespace FlightBookService.Models
{
    public partial class TblBookingDetail
    {
        public int BookingId { get; set; }
        public int FlightNumber { get; set; }
        public string Pnr { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public int? TotalSeat { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
