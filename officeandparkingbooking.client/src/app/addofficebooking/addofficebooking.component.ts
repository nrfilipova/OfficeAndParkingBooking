import { Component, OnInit } from '@angular/core';
import { AddOfficeBookingService } from './addofficebooking.service';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { format } from "date-fns";
import { IRooms } from './roomsmodel';

@Component({
  selector: 'app-addofficebooking',
  templateUrl: './addofficebooking.component.html',
  styleUrl: './addofficebooking.component.css'
})
export class AddOfficeBookingComponent{
  
  public form: FormGroup = new FormGroup({
    date: new FormControl('', Validators.required),
    roomId: new FormControl('', Validators.required),
    notes: new FormControl(),
  });
  
  public rooms: IRooms[] =[];

  constructor(
    private bookingService: AddOfficeBookingService
  ) {}

  ngOnInit(): void{
    this.loadRooms();
  }

  loadRooms(): void{
    this.bookingService.getRooms().subscribe({ 
      next: (data: IRooms[]) => {
        this.rooms = data;
    }});
  }

  onSubmit(): void{
    const formValues = this.form.value;
    formValues.date = format(formValues.date, "yyyy-MM-dd");
    
    this.bookingService.postOfficeBookings(formValues).subscribe({ 
      next: (response) => {
      this.rooms = this.rooms;
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