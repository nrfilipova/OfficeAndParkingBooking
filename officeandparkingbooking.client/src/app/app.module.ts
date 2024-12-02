import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ParkingbookingcomponentComponent } from './parkingbookingcomponent/parkingbookingcomponent.component';
import { OfficeBookingcomponentComponent } from './officebookingcomponent/officebookingcomponent.component';
import { AddOfficeBookingComponent } from './addofficebooking/addofficebooking.component';
import { AddParkingbookingComponent } from './addparkingbooking/addparkingbooking.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

import { GridModule } from '@progress/kendo-angular-grid';
import { DateInputsModule } from "@progress/kendo-angular-dateinputs";
import { LabelModule } from "@progress/kendo-angular-label";
import { InputsModule } from "@progress/kendo-angular-inputs";
import { ButtonsModule } from "@progress/kendo-angular-buttons";
import { DropDownsModule } from "@progress/kendo-angular-dropdowns";
import { GlobalErrorHandlerService } from './global-error-handler.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    ParkingbookingcomponentComponent,
    OfficeBookingcomponentComponent,
    AddOfficeBookingComponent,
    AddParkingbookingComponent,
    LoginComponent,
    RegisterComponent
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
    ButtonsModule,
    DropDownsModule,
    MatSnackBarModule
  ],
  providers: [
    {provide: ErrorHandler, useClass: GlobalErrorHandlerService}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }