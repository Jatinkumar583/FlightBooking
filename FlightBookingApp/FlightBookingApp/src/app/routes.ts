import { Routes } from "@angular/router";
import { ScheduledFlight } from "./home/scheduleflight/scheduleflight.component";
import { HomeComponent } from "./home/home.component";
import { NewairlineComponent } from "./home/newairline/newairline.component";
import { UserComponent } from "./user/user.component";
import { LoginComponent } from "./user/login/login.component";

export const appRoutes: Routes = [
    {
        path: 'home', component: HomeComponent
    },
    {
        path: 'login', component: LoginComponent
    },
    {
        path: '', redirectTo: '/login', pathMatch: 'full'
    },
    {
        path: 'scheduleflight', component: ScheduledFlight
    },
    {
        path: 'newairline', component: NewairlineComponent
    },

];