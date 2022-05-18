using FlightBookService.Models;
using FlightBookService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookService.Services
{
    public interface IUserRegistration
    {
        void RegisterUser(UserRegistDetails users);
        TblUser GetUserDetails(User userDetails);
    }
}
