import { Injectable } from '@angular/core';
import { AirlineInventory } from '../models/airlinedata';

@Injectable()
export class FilterPanelService {

  selectedFlightDetails: AirlineInventory=new AirlineInventory();
  constructor() { }

   get data(): any{
    return this.selectedFlightDetails;
  }

  set data(val: any){
    this.selectedFlightDetails = val;
  }

}