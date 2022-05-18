import { Router } from "@angular/router";
import { UserData } from "../models/UserData";
import { HttpClient } from '@angular/common/http'
import { Injectable } from "@angular/core";
import { BookingDetails } from "../models/bookingdetails";

@Injectable()
export class EventService {
    private _eventUrl = "http://localhost:64350/api/v1.0/flight/airline/register";

    constructor(private http: HttpClient, private _router: Router) {

    }
    saveNewAirline(data: any) {
        return this.http.post("http://localhost:64350/api/v1.0/flight/airline/register", data);
    }
    GetAirlineList() {
        return this.http.get<any>("http://localhost:64350/api/v1.0/flight/airline/inventory/list");
    }

    BookCustomerFlight(data:BookingDetails){        
        return this.http.post("http://localhost:55167/api/v1.0/flight/booking/flightdetails", data,{ responseType: 'text'});
    }

    GetBookedDetailsByEmailId(userEmailId:string){
        return this.http.get<any>("http://localhost:55167/api/v1.0/flight/booking/history/"+userEmailId+"");
    }

    GetBookedPassengerDetails(bookingId:Number){
        return this.http.get<any>("http://localhost:55167/api/v1.0/flight/booking/history/"+bookingId+"");
    }



}