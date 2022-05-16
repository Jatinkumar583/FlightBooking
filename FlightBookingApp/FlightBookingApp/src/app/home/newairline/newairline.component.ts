import { Component, OnInit } from '@angular/core';
import {HttpClient,HttpParams} from '@angular/common/http';
import { AddNewAirline } from './newairline.model';
import { DatePipe } from '@angular/common';
import { EventService } from '../../services/events.service';
import { AuthService } from '../../services/auth.service';
import { UserData } from '../../models/userdata';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-newairline',
  templateUrl: './newairline.component.html',
  providers: [DatePipe]
})
export class NewairlineComponent{
  

  constructor(private _eventService:EventService) {
    
  }
  NewAirlineModel: AddNewAirline = new AddNewAirline();  
  loginUserData: UserData = new UserData();
  
  
  
  SuccessGet(res:any){    
    //this.AirlineList.
    this.NewAirlineModel.airlineName="";
    this.NewAirlineModel.contactNumber="";
    this.NewAirlineModel.contactAddress="";
     
    Swal.fire({  
      position: 'center',  
      icon: 'success',  
      text: 'Submitted Succesfully!'
    })   
  }
  ErrorGet(res:any){
    console.log(res);
    Swal.fire({  
      position: 'center',  
      icon: 'error',  
      title: 'Oops...',  
      text: 'Something went wrong!'
    })  
  }
  AddNewAirline() {
    var airlinedto={
      airlineName: this.NewAirlineModel.airlineName,
      uploadLogo:  null,
      contactNumber: this.NewAirlineModel.contactNumber,
      contactAddress: this.NewAirlineModel.contactAddress,
      createdBy: 1,    //for now
      createdOn: JSON.stringify(new Date()).slice(1,11),
      updatedBy: 1,
      updatedOn: JSON.stringify(new Date()).slice(1,11)
    }
    // this.loginUserData.name="Jatin";
    // this.loginUserData.password="1234";     
    //   this._auth.loginUser(this.loginUserData).subscribe(res => {
    //     localStorage.setItem('token', res.token)      
    //   },
    //     err => console.log(err));
     this._eventService.saveNewAirline(airlinedto).subscribe(res=>this.SuccessGet(res),res=>this.ErrorGet(res));
  }

}
