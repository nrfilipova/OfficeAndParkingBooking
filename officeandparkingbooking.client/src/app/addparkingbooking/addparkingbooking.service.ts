import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddParkingBookingModel} from './addparkingbookingmodel';

@Injectable({
  providedIn: 'root'
})
export class AddParkingBookingService {
  constructor(private http: HttpClient) {}
  
  private apiUrl = 'https://localhost:7014/ParkingBooking';

  postOfficeBookings(booking: AddParkingBookingModel): Observable<AddParkingBookingModel> {
    const token = localStorage.getItem('accessToken');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    })

    return this.http.post<AddParkingBookingModel>(this.apiUrl, booking, { headers });
  }
}