
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { AirlineInventory } from 'src/app/models/airlinedata';
import { EventService } from 'src/app/services/events.service';

@Component({
  selector: 'app-scheduleflight',
  templateUrl: './scheduleflight.component.html'
})
export class ScheduledFlight implements OnInit {
  AirlineList: Array<AirlineInventory> = new Array<AirlineInventory>();
  tblShow: boolean = false;
  filteredRecord: Array<AirlineInventory> = new Array<AirlineInventory>();
  SearchAirlineList: Array<AirlineInventory> = new Array<AirlineInventory>();
  constructor(private _eventService: EventService) {

  }
  ngOnInit(): any {
    this._eventService.GetAirlineList().subscribe(res => this.AirlineList = res.reduce((accumalator: any, current: any) => {
      if (
        !accumalator.some(
          (item: any) => item.airlineId === current.airlineId)
      ) {
        accumalator.push(current);
      }
      return accumalator;
    }, []), err => console.log(err))
  }
  GetAirlineList(data: any) {
    this._eventService.GetAirlineList().subscribe(res => this.SearchAirlineList = res, err => console.log(err));
    this.filteredRecord = this.SearchAirlineList.filter(function (item) {
      return item.airlineId == data.ddlAirlineId || item.flightNumber == Number(data.txtFlightNumber);
    });
    console.log(this.filteredRecord);
    this.tblShow = true;
  }
}
