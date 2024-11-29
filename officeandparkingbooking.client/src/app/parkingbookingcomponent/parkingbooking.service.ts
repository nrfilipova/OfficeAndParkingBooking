import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IParkingeBookingModel } from './parkingbookingmodel';

@Injectable({
    providedIn: 'root'
  })
export class ParkingBookingService {
    constructor(private http: HttpClient) {}
    
    private apiUrl = 'https://localhost:7014/parkingBooking';
  
    getParkingBookings(): Observable<IParkingeBookingModel[]> {
      return this.http.get<IParkingeBookingModel[]>(this.apiUrl);
    }
  }