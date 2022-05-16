import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable, Injector } from "@angular/core";
import { Observable } from "rxjs";
import { AuthService } from "./auth.service";

@Injectable()
export class TokenInterceptorService implements HttpInterceptor{
 
    constructor(private injector:Injector) {}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let authService=this.injector.get(AuthService);
        let tokenizedReq=req.clone({
            //headers:req.headers.set('Authorization','bearer '+authService.getToken())
            setHeaders: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem('token')}`
              }
        })
        return next.handle(tokenizedReq)
    }
}