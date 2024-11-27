import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ParkingbookingcomponentComponent } from './parkingbookingcomponent/parkingbookingcomponent.component';
import { OfficeBookingcomponentComponent } from './officebookingcomponent/officebookingcomponent.component';

import {GridModule} from '@progress/kendo-angular-grid';
import { AddofficebookingComponent } from './addofficebooking/addofficebooking.component';
import { AddparkingbookingComponent } from './addparkingbooking/addparkingbooking.component';


@NgModule({
  declarations: [
    AppComponent,
    ParkingbookingcomponentComponent,
    OfficeBookingcomponentComponent,
    AddofficebookingComponent,
    AddparkingbookingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    GridModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
