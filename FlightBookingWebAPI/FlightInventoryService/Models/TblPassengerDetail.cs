using System;
using System.Collections.Generic;

#nullable disable

namespace FlightInventoryService.Models
{
    public partial class TblPassengerDetail
    {
        public int PassDetailsId { get; set; }
        public int BookingId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerGender { get; set; }
        public int? PassengerAge { get; set; }
        public string MealOption { get; set; }
        public int? SelectedSeatNumber { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
