import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
//import { UserData } from '../models/UserData';
@Injectable()
export class AuthService{
    private _registerUrl = "";
    private _loginUrl = "http://localhost:55167/api/users/authenticate";

    constructor(private http: HttpClient, private _router: Router) {

    }

    loginUser(user: any) {
        return this.http.post<any>(this._loginUrl, user)
    }
    registerUser(user: any) {
        console.log(user);
        return this.http.post<any>(this._registerUrl, user)
    }

    logoutUser() {
        localStorage.removeItem('token')
        this._router.navigate(['/login'])
    }

    getToken() {
        return localStorage.getItem('token')
    }
    loggedIn() {
        return !!localStorage.getItem('token')
    }
}