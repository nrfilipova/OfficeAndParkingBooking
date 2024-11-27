import { Component} from '@angular/core';
import { AddOfficeBookingModel } from './addofficebookingmodel';
import { AddOfficeBookingService } from './addofficebooking.service';

@Component({
  selector: 'app-addofficebooking',
  templateUrl: './addofficebooking.component.html',
  styleUrl: './addofficebooking.component.css'
})
export class AddOfficebookingComponent{

  public booking = new AddOfficeBookingModel('','', '', '');

  constructor(
    private bookingService: AddOfficeBookingService
  ) {}

  
  onSubmit(): void{
    this.bookingService.postOfficeBookings(this.booking)
  }

}

