using FlightInventoryService.Events;
using FlightInventoryService.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInventoryService.Consumers
{
    public class VedioDeletedEventConsumer : IConsumer<VedioDeletedEvent>
    {
        FlightBookingContext _flightBookingContext;
        public VedioDeletedEventConsumer(FlightBookingContext flightBookingContext)
        {
            _flightBookingContext = flightBookingContext;
        }
        public Task Consume(ConsumeContext<VedioDeletedEvent> context)
        {
            try
            {
                if (context.Message.TotalSeat != 0)
                {
                    var entity = _flightBookingContext.TblAirlineInventories.FirstOrDefault(item => item.FlightNumber == context.Message.FlightNumber);
                    if (entity != null)
                    {
                        entity.TotalBussClassSeats = entity.TotalBussClassSeats - context.Message.TotalSeat;
                        _flightBookingContext.SaveChanges();
                    }
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
