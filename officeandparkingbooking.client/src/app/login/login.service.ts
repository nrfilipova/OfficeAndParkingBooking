import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LoginModel } from './login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) {}

  private apiUrl = 'https://localhost:7014/api/identity/login';

  login(booking: LoginModel): Observable<LoginModel> {
    return this.http.post<LoginModel>(this.apiUrl, booking).pipe(
      tap((response) => {
        if (response && response.accessToken) {
          localStorage.setItem('token', response.accessToken);
        }
      })
    );
  }
}