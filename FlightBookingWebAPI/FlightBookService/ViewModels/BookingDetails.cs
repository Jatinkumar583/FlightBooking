using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookService.ViewModels
{
    public class BookingDetails
    {
        public int FlightNumber { get; set; }
        public string Pnr { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public int? TotalSeat { get; set; }
        public PassengerDetails[] PassengerLists { get; set; }        
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class PassengerDetails
    {
        public string PassengerName { get; set; }
        public string PassengerGender { get; set; }
        public int? PassengerAge { get; set; }
        public string MealOption { get; set; }
        public int? SelectedSeatNumber { get; set; }
    }
}
