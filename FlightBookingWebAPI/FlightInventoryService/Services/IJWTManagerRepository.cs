using FlightInventoryService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInventoryService.Services
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}
