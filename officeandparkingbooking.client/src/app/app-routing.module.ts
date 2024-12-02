import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OfficeBookingcomponentComponent } from './officebookingcomponent/officebookingcomponent.component';
import { ParkingbookingcomponentComponent } from './parkingbookingcomponent/parkingbookingcomponent.component';
import { AddOfficeBookingComponent } from './addofficebooking/addofficebooking.component';
import { AddParkingbookingComponent } from './addparkingbooking/addparkingbooking.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'officebooking', component: OfficeBookingcomponentComponent},
  { path: 'parkingbooking', component: ParkingbookingcomponentComponent},
  { path: 'addofficebooking', component: AddOfficeBookingComponent},
  { path: 'addparkingbooking', component: AddParkingbookingComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
