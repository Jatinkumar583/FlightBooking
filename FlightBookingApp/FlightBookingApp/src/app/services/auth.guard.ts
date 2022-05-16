import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
//import { UserData } from '../models/UserData';
@Injectable()
export class AuthGuard{
    constructor(private _authService:AuthService,private _router:Router) {
    }
}