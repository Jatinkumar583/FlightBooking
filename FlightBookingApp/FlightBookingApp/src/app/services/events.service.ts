import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
//import { UserData } from '../models/UserData';
@Injectable()
export class EventService{
    constructor(private http: HttpClient, private _router: Router) {

    }
    getToken() {
        return localStorage.getItem('token')
    }
    saveNewAirline(data:any){
        return this.http.post("http://localhost:64350/api/v1.0/flight/airline/register", data);
    }
  GetAirlineList(){   
   return this.http.get<any>("http://localhost:64350/api/v1.0/flight/airline/inventory/list");
  }
  SearchFlight(){
      
  }
}