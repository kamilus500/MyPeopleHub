import { Injectable } from '@angular/core';
import { UserDto } from '../models/UserDto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'http://localhost:5131';

  constructor(private httpClient: HttpClient) { }

  getAllUser(): Observable<UserDto[]> {
    return this.httpClient.get<UserDto[]>(this.apiUrl + '/GetAllUsers/');
  }

  getUserById(userId: string): Observable<UserDto> {
    return this.httpClient.get<UserDto>(this.apiUrl + `/GetUserById/${userId}`);
  }
}
