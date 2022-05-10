using FlightSearchService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchService.Services
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}
