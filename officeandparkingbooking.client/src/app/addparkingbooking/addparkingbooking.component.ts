import { Component } from '@angular/core';
import { AddParkingBookingService } from './addparkingbooking.service';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { ISpots } from './parkingspotmodel';
import { IRegistrationPlate } from './carregistrationplatesandmodels';

@Component({
  selector: 'app-addparkingbooking',
  templateUrl: './addparkingbooking.component.html',
  styleUrl: './addparkingbooking.component.css'
})
export class AddParkingbookingComponent {

  public form: FormGroup = new FormGroup({
    arrival: new FormControl(new Date(), Validators.required),
    departure: new FormControl(new Date(), Validators.required),
    spotId: new FormControl('', Validators.required),
    registrationPlate: new FormControl('', Validators.required),
  });
  
  public spots: ISpots[] =[];
  public plates: IRegistrationPlate[] =[];

  constructor(
    private bookingService: AddParkingBookingService
  ) {}

  ngOnInit(): void{
    this.loadSpots();
    this.loadPlates();
  }

  loadSpots(): void{
    this.bookingService.getSpots().subscribe({ 
      next: (data: ISpots[]) => {
        this.spots = data;
    }});
  }

  loadPlates(): void{
    this.bookingService.getPlates().subscribe({ 
      next: (data: IRegistrationPlate[]) => {
        this.plates = data;
    }});
  }

  onSubmit(): void{
    const formValues = this.form.value;
      this.bookingService.postOfficeBookings(formValues).subscribe({ 
        next: () => {
        this.spots = this.spots;
        this.plates = this.plates;
        this.form.reset(); 
        alert("Booking added successfully");
      }
    });
  };

  public submitForm(): void {
    this.form.markAllAsTouched();
  }

  public clearForm(): void {
    this.form.reset();
  }
}
