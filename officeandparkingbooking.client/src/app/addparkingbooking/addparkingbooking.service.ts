import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddParkingBookingModel} from './addparkingbookingmodel';

@Injectable({
  providedIn: 'root'
})
export class AddParkingBookingService {
  constructor(private http: HttpClient) {}
  
  private apiUrl = 'https://localhost:7014/ParkingBooking';

  postOfficeBookings(booking: AddParkingBookingModel): Observable<AddParkingBookingModel> {
    return this.http.post<AddParkingBookingModel>(this.apiUrl, booking);
  }
}