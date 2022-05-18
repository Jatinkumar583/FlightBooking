import { Component, OnInit, ViewChild } from '@angular/core';
import { BookedDetails } from '../models/bookeddetails';
import { BookedPassengerDetails } from '../models/bookedpassenger';
import { EventService } from '../services/event.service';
import { FilterPanelService } from '../services/filterpanel';

@Component({
  selector: 'app-ticketdetails',
  templateUrl: './ticketdetails.component.html',
  styleUrls: ['./ticketdetails.component.css']
})
export class TicketdetailsComponent implements OnInit {
  passengerDetails:Array<BookedPassengerDetails>=new Array<BookedPassengerDetails>();
  ticketDetails: BookedDetails=new BookedDetails();
  @ViewChild('BookinghistoryComponent', {static : false}) filterPanel: any;  
  constructor(public filterPanelService: FilterPanelService,
    private _eventService: EventService) {
    
  }

  ngOnInit(): void {
    this.ticketDetails=this.filterPanelService.BookedData;
    console.log(this.ticketDetails)
    this._eventService.GetBookedPassengerDetails(this.ticketDetails.bookingId).subscribe(res=>this.SuccessGet(res),res=>this.ErrorGet(res));
    //bind to model ==BookingDetails
  }
  SuccessGet(res:any){    
    this.passengerDetails = res
    console.log(this.passengerDetails)
  }
  ErrorGet(res:any){
    console.log(res);     
  }

}
