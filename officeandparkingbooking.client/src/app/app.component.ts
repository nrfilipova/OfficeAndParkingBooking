import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';
import { IOfficeBookingModel } from './officebookingmodel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'grid';
  public bookingData: IOfficeBookingModel[] = [];

  constructor(private employeeService: EmployeeService) {}

  ngOnInit() {
    this.employeeService.getEmployees().subscribe((model) => {
        this.bookingData = model;
      }
    );
  }
}