using FlightBookService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookService.Services
{
   public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}
