import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserData } from '../models/userdata';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {

  loginUserData: UserData = new UserData();
  constructor(private _auth: AuthService, private _router: Router) { }
  loginUser() {
    console.log("hit");   
    this._router.navigate(['/home'])
  }

}
