using System;
using System.Collections.Generic;

#nullable disable

namespace FlightInventoryService.Models
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginType { get; set; }
    }
}
