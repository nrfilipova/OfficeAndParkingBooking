import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddOfficeBookingModel } from './addofficebookingmodel';
import { IRooms } from './roomsmodel';

@Injectable({
  providedIn: 'root'
})

export class AddOfficeBookingService {
  constructor(private http: HttpClient) {}
  
  private apiUrl = 'https://localhost:7014/OfficeBooking';
  private roomApiUrl = 'https://localhost:7014/GetRooms';
  
  postOfficeBookings(booking: AddOfficeBookingModel): Observable<AddOfficeBookingModel> {
    const token = localStorage.getItem('accessToken');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
    
    return this.http.post<AddOfficeBookingModel>(this.apiUrl, booking, { headers });
  }

  getRooms(): Observable<IRooms[]> {
    return this.http.get<IRooms[]>(this.roomApiUrl);
  }
}