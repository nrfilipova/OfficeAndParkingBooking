import { Component } from '@angular/core';
import { AddParkingBookingService } from './addparkingbooking.service';
import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
  selector: 'app-addparkingbooking',
  templateUrl: './addparkingbooking.component.html',
  styleUrl: './addparkingbooking.component.css'
})
export class AddParkingbookingComponent {

  public form: FormGroup = new FormGroup({
    arrival: new FormControl('', Validators.required),
    departure: new FormControl('', Validators.required),
    parkingSpot: new FormControl(),
    registrationPlate: new FormControl(),
    carModel: new FormControl(),
  });
  
  constructor(
    private bookingService: AddParkingBookingService
  ) {}

  onSubmit(): void{
    const formValues = this.form.value;
    this.bookingService.postOfficeBookings(formValues).subscribe({ 
      next: (response) => {
      this.form.reset(); 
    }});
  };

  public submitForm(): void {
    this.form.markAllAsTouched();
  }

  public clearForm(): void {
    this.form.reset();
  }
}
