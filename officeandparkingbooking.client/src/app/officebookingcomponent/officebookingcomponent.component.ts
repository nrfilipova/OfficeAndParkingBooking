import { Component, OnInit } from '@angular/core';
import { OfficeBookingService } from './officebooking.service';
import { IOfficeBookingModel } from './officebookingmodel';

@Component({
  selector: 'app-officebookingcomponent',
  templateUrl: './officebookingcomponent.component.html',
  styleUrl: './officebookingcomponent.component.css'
})
export class OfficeBookingcomponentComponent implements OnInit {
  public officeBookingData: IOfficeBookingModel[] = [];
  
  constructor(
    private officeBookingService: OfficeBookingService
  ) {}

  ngOnInit() {
    this.officeBookingService.getOfficeBookings().subscribe((model) => {
      this.officeBookingData = model;
      }
    );
  }
}