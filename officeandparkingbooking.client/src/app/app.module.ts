import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ParkingbookingcomponentComponent } from './parkingbookingcomponent/parkingbookingcomponent.component';
import { OfficeBookingcomponentComponent } from './officebookingcomponent/officebookingcomponent.component';
import { AddOfficebookingComponent } from './addofficebooking/addofficebooking.component';
import { AddparkingbookingComponent } from './addparkingbooking/addparkingbooking.component';

import {GridModule} from '@progress/kendo-angular-grid';
import { DateInputsModule } from "@progress/kendo-angular-dateinputs";
import { LabelModule } from "@progress/kendo-angular-label";
import { InputsModule } from "@progress/kendo-angular-inputs";
import { ButtonsModule } from "@progress/kendo-angular-buttons";

@NgModule({
  declarations: [
    AppComponent,
    ParkingbookingcomponentComponent,
    OfficeBookingcomponentComponent,
    AddOfficebookingComponent,
    AddparkingbookingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    GridModule,
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DateInputsModule,
    InputsModule,
    LabelModule,
    ButtonsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
