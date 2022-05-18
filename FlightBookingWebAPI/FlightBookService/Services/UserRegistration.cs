using FlightBookService.Models;
using FlightBookService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookService.Services
{
    public class UserRegistration: IUserRegistration
    {
        FlightBookingContext _flightBookingContext;
        public UserRegistration(FlightBookingContext flightBookingContext)
        {
            _flightBookingContext = flightBookingContext;
        }

        public TblUser GetUserDetails(User userDetails)
        {
            return _flightBookingContext.TblUsers.Where(x => x.EmailId == userDetails.UserName).FirstOrDefault();
        }

        public void RegisterUser(UserRegistDetails users)
        {
            TblUser tblUser = new TblUser
            {
                UserName = users.UserName,
                EmailId = users.EmailId,
                Password = users.Password,
                LoginType = users.LoginType,
                UpdatedBy = null,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn=DateTime.UtcNow
            };
            _flightBookingContext.TblUsers.Add(tblUser);
            _flightBookingContext.SaveChanges();
        }
    }
}
