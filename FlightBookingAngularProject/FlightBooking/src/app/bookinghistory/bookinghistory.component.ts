import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookedDetails } from '../models/bookeddetails';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-bookinghistory',
  templateUrl: './bookinghistory.component.html',
  styleUrls: ['./bookinghistory.component.css']
})
export class BookinghistoryComponent implements OnInit {
  bookedFlightDetails:Array<BookedDetails>=new Array<BookedDetails>(); 
  searchBookedFlightList: Array<BookedDetails> = new Array<BookedDetails>();
  constructor(private _eventService: EventService,private _router: Router) { }

  ngOnInit(): void {
    var userEmailId=localStorage.getItem('emailId')!;
    this._eventService.GetBookedDetailsByEmailId(userEmailId).subscribe(res => this.bookedFlightDetails = res, err => (console.log(err)));
  }

  GetBookedFlightDetails(data: any) {    
    var userEmailId=localStorage.getItem('emailId')!;
    this._eventService.GetBookedDetailsByEmailId(userEmailId).subscribe(res => this.searchBookedFlightList = res, err => (console.log(err),this._router.navigate(['/login'])));
    this.bookedFlightDetails = this.searchBookedFlightList.filter(function (item) {
      return item.pnr == data.txtPnr || item.emailId == data.txtUserEmailId;
    });
    console.log(this.bookedFlightDetails);
  }


}
