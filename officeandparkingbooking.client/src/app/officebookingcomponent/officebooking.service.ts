import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IOfficeBookingModel } from './officebookingmodel';

@Injectable({
  providedIn: 'root'
})
export class OfficeBookingService {
  constructor(private http: HttpClient) {}
  
  private apiUrl = 'https://localhost:7014/OfficeBooking';

  getOfficeBookings(): Observable<IOfficeBookingModel[]> {
    return this.http.get<IOfficeBookingModel[]>(this.apiUrl);
  }
}