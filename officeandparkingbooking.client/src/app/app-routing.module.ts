import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OfficeBookingcomponentComponent as OfficeBookingcomponentComponent } from './officebookingcomponent/officebookingcomponent.component';
import { ParkingbookingcomponentComponent } from './parkingbookingcomponent/parkingbookingcomponent.component';

const routes: Routes = [
  {path: 'officebooking', component: OfficeBookingcomponentComponent},
  { path: 'parkingbooking', component: ParkingbookingcomponentComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
