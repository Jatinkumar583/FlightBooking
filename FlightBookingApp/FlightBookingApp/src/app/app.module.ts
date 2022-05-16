import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './home/navbar/navbar.component';
import { SidebarComponent } from './home/sidebar/sidebar.component';
import { ScheduledFlight } from './home/scheduleflight/scheduleflight.component';
import { FormGroup, FormsModule } from '@angular/forms';
import { NewairlineComponent } from './home/newairline/newairline.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { EventService } from './services/events.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth.guard';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { UserComponent } from './user/user.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './user/login/login.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    ScheduledFlight,
    NewairlineComponent,
    LoginComponent,
    UserComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpClientModule
  ],
  providers: [EventService,AuthService,AuthGuard,
  {provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptorService,
    multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
