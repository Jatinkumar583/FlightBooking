using FlightBookService.Events;
using FlightBookService.Models;
using FlightBookService.ViewModels;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookService.Services
{
    public class TicketBooking : ITicketBooking
    {
        FlightBookingContext _flightBookingContext;
        private ITopicProducer<VedioDeletedEvent> _topicProducer;
        public TicketBooking(FlightBookingContext flightBookingContext, ITopicProducer<VedioDeletedEvent> topicProducer)
        {
            _flightBookingContext = flightBookingContext;
            _topicProducer = topicProducer;
        }

        public int BookFlight(BookingDetails bookingDetail)
        {
            using (var transaction = _flightBookingContext.Database.BeginTransaction())
            {
                try
                {
                    #region Inserting record to BookingDetails table
                    TblBookingDetail tblBookingDetail = new TblBookingDetail
                    {
                        FlightNumber = bookingDetail.FlightNumber,
                        Pnr = bookingDetail.Pnr,
                        Source = bookingDetail.Source,
                        Destination = bookingDetail.Destination,
                        UserName = bookingDetail.UserName,
                        EmailId = bookingDetail.EmailId,
                        TotalSeat = bookingDetail.TotalSeat,
                        CreatedBy = bookingDetail.CreatedBy,
                        CreatedOn = bookingDetail.CreatedOn,
                        UpdatedBy = bookingDetail.UpdatedBy,
                        UpdatedOn = bookingDetail.UpdatedOn
                    };
                    _flightBookingContext.TblBookingDetails.Add(tblBookingDetail);
                    _flightBookingContext.SaveChanges();
                    int bookingId = tblBookingDetail.BookingId;
                    #endregion

                    #region Inserting record to PassengerDetails table
                    for (int i = 0; i < bookingDetail.PassengerLists.Count(); i++)
                    {
                        if (bookingId != 0)
                        {
                            TblPassengerDetail tblPassengerDetail = new TblPassengerDetail
                            {
                                BookingId = bookingId,
                                PassengerName = bookingDetail.PassengerLists[i].PassengerName,
                                PassengerGender = bookingDetail.PassengerLists[i].PassengerGender,
                                PassengerAge = bookingDetail.PassengerLists[i].PassengerAge,
                                MealOption = bookingDetail.PassengerLists[i].MealOption,
                                SelectedSeatNumber = bookingDetail.PassengerLists[i].SelectedSeatNumber,
                                CreatedBy = bookingDetail.CreatedBy,
                                CreatedOn = bookingDetail.CreatedOn,
                                UpdatedBy = bookingDetail.UpdatedBy,
                                UpdatedOn = bookingDetail.UpdatedOn
                            };

                            _flightBookingContext.TblPassengerDetails.Add(tblPassengerDetail);
                            _flightBookingContext.SaveChanges();
                        }
                    }
                    #endregion
                    
                    transaction.Commit();

                    #region Sending data to inventory microservice to deduct the number of seat booked
                    VedioDeletedEvent vedioDeletedEvent = new VedioDeletedEvent()
                    {
                        FlightNumber = bookingDetail.FlightNumber,
                        Pnr = bookingDetail.Pnr,
                        Source = bookingDetail.Source,
                        Destination = bookingDetail.Destination,
                        UserName = bookingDetail.UserName,
                        EmailId = bookingDetail.EmailId,
                        TotalSeat = bookingDetail.TotalSeat,
                    };
                    SendDataToConsumer(vedioDeletedEvent);
                    #endregion
                    return 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
        }
        public async Task<IActionResult> SendDataToConsumer(VedioDeletedEvent vedioDeletedEvent)
        {
            await _topicProducer.Produce(vedioDeletedEvent);
            return null;
        }

        public int CancelBookedTicketByPNR(string pnr)
        {
            using (var transaction = _flightBookingContext.Database.BeginTransaction())
            {
                try
                {
                    #region Deleting from tblBooking table
                    var itemToRemove = _flightBookingContext.TblBookingDetails.SingleOrDefault(x => x.Pnr == pnr);
                    if (itemToRemove != null)
                    {
                        _flightBookingContext.TblBookingDetails.Remove(itemToRemove);
                        _flightBookingContext.SaveChanges();
                    }
                    #endregion
                    #region Deleting from tblPassenger table

                    var itemLIst = _flightBookingContext.TblPassengerDetails.Where(x => x.BookingId == itemToRemove.BookingId).ToList();
                    if (itemLIst.Count > 0)
                    {
                        foreach (var item in itemLIst)
                        {
                            _flightBookingContext.TblPassengerDetails.Remove(item);
                        }
                         _flightBookingContext.SaveChanges();
                    }
                    #endregion
                    #region Update the seat to tblAirlineInventory table
                    var entity = _flightBookingContext.TblAirlineInventories.FirstOrDefault(item => item.FlightNumber == itemToRemove.FlightNumber);
                    // Validate entity is not null
                    if (entity != null)
                    {
                        // Make changes on entity
                        entity.TotalBussClassSeats = entity.TotalBussClassSeats+ itemToRemove.TotalSeat;
                        // Save changes in database
                        _flightBookingContext.SaveChanges();
                    }
                    #endregion

                    transaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return 0;
                }

            }

        }

        public List<TblBookingDetail> GetBookingDetailsByEmailId(string emailId)
        {
            return _flightBookingContext.TblBookingDetails.Where(x => x.EmailId == emailId).ToList();
        }

        public List<TblPassengerDetail> GetPassengerDetails(int bookingId)
        {
            return _flightBookingContext.TblPassengerDetails.Where(x => x.BookingId == bookingId).ToList();
        }
    }
}
