import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html'
})
export class SidebarComponent implements OnInit {

  constructor(private _authservice: AuthService) { }

  ngOnInit(): void {
  }  
  logout(){
    this._authservice.logoutUser();
  }
}
