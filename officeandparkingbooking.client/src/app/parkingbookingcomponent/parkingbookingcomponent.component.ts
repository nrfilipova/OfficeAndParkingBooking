import { Component, OnInit } from '@angular/core';
import {IParkingeBookingModel} from './parkingbookingmodel';
import { ParkingBookingService } from './parkingbooking.service';

@Component({
  selector: 'app-parkingbookingcomponent',
  templateUrl: './parkingbookingcomponent.component.html',
  styleUrl: './parkingbookingcomponent.component.css'
})
export class ParkingbookingcomponentComponent implements OnInit{

  public parkingBookingData: IParkingeBookingModel[] = [];

  constructor( 
    private parkingBookingservice: ParkingBookingService
  ) {}

  ngOnInit() {
    this.parkingBookingservice.getParkingBookings().subscribe((model) => {
      this.parkingBookingData = model;
    }
    );
  }
}