import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddParkingBookingModel} from './addparkingbookingmodel';
import { ISpots } from './parkingspotmodel';
import { IRegistrationPlate } from './carregistrationplatesandmodels';

@Injectable({
  providedIn: 'root'
})
export class AddParkingBookingService {
  constructor(private http: HttpClient) {}
  
  private apiUrl = 'https://localhost:7014/parkingBooking';
  private spotApiUrl = 'https://localhost:7014/spots';
  private platesApiUrl = 'https://localhost:7014/registrationPlates';

  postOfficeBookings(booking: AddParkingBookingModel): Observable<AddParkingBookingModel> {
    const token = localStorage.getItem('accessToken');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    })
    return this.http.post<AddParkingBookingModel>(this.apiUrl, booking, { headers });
  }

  getSpots(): Observable<ISpots[]> {
    return this.http.get<ISpots[]>(this.spotApiUrl);
  }

  getPlates(): Observable<IRegistrationPlate[]> {
    const token = localStorage.getItem('accessToken');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    })
    return this.http.get<IRegistrationPlate[]>(this.platesApiUrl, { headers });
  }
}