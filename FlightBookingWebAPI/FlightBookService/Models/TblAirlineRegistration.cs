using System;
using System.Collections.Generic;

#nullable disable

namespace FlightBookService.Models
{
    public partial class TblAirlineRegistration
    {
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public byte[] UploadLogo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
