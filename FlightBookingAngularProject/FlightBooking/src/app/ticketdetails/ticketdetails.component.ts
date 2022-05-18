import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BookedDetails } from '../models/bookeddetails';
import { BookedPassengerDetails } from '../models/bookedpassenger';
import { BookingDetails } from '../models/bookingdetails';
import { PassengerDetails } from '../models/passengerdetails';
import { EventService } from '../services/event.service';
import { FilterPanelService } from '../services/filterpanel';

@Component({
  selector: 'app-ticketdetails',
  templateUrl: './ticketdetails.component.html',
  styleUrls: ['./ticketdetails.component.css']
})
export class TicketdetailsComponent implements OnInit {
  passengerDetails:Array<PassengerDetails>=new Array<PassengerDetails>();
  ticketDetails: BookedDetails=new BookedDetails();
  BookingDetails: BookingDetails=new BookingDetails();
  @ViewChild('BookinghistoryComponent', {static : false}) filterPanel: any;  
  constructor(public filterPanelService: FilterPanelService,
    private _eventService: EventService,public datepipe: DatePipe) {
    
  }

  ngOnInit(): void {
    this.ticketDetails=this.filterPanelService.BookedData;
    console.log(this.ticketDetails)
    this._eventService.GetBookedPassengerDetails(this.ticketDetails.bookingId).subscribe(res=>this.SuccessGet(res),res=>this.ErrorGet(res));
  
  }
  SuccessGet(res:any){    
    this.passengerDetails = res   
      //bind to model ==BookingDetails
      this.BookingDetails.FlightNumber=this.ticketDetails.flightNumber;
      this.BookingDetails.Pnr=this.ticketDetails.pnr;
      this.BookingDetails.Source=this.ticketDetails.source;
      this.BookingDetails.Destination=this.ticketDetails.destination;
      this.BookingDetails.TotalSeat=this.ticketDetails.totalSeat;
      this.BookingDetails.CreatedOn= this.ticketDetails.createdOn;
      this.BookingDetails.PassengerLists=this.passengerDetails
      console.log(this.BookingDetails);
  }
  ErrorGet(res:any){
    console.log(res);     
  }

}
