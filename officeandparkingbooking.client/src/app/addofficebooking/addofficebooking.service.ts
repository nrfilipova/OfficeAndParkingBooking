import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddOfficeBookingModel } from './addofficebookingmodel';


@Injectable({
  providedIn: 'root'
})
export class AddOfficeBookingService {
  constructor(private http: HttpClient) {}
  
  private apiUrl = 'https://localhost:7014/OfficeBooking';

  postOfficeBookings(booking: AddOfficeBookingModel): Observable<AddOfficeBookingModel> {
    return this.http.post<AddOfficeBookingModel>(this.apiUrl, booking);
  }
}