import { Component} from '@angular/core';
import { AddOfficeBookingService } from './addofficebooking.service';
import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
  selector: 'app-addofficebooking',
  templateUrl: './addofficebooking.component.html',
  styleUrl: './addofficebooking.component.css'
})
export class AddOfficeBookingComponent{
  
  public form: FormGroup = new FormGroup({
    date: new FormControl('', Validators.required),
    room: new FormControl('', Validators.required),
    notes: new FormControl(),
  });
  
  constructor(
    private bookingService: AddOfficeBookingService
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