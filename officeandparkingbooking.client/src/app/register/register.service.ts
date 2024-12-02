import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterModel } from './register';
import { ITeam } from './teammodel';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  constructor(private http: HttpClient) {}

  private apiUrl = 'https://localhost:7014/api/identity/Employee/register';
  private teamsUrl = 'https://localhost:7014/teams';

  register(data: RegisterModel): Observable<RegisterModel> {
    return this.http.post<RegisterModel>(this.apiUrl, data);
  }

  getTeams(): Observable<ITeam[]> {
    return this.http.get<ITeam[]>(this.teamsUrl);
  }
}