import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterDto } from '../models/RegisterDto';
import { BehaviorSubject, Observable, ReplaySubject, Subject } from 'rxjs';
import { LoginDto } from '../models/LoginDto';
import { LoginResponse } from '../models/LoginResponse';
import { TokenService } from './token.service';
import { AccountDataService } from './data-services/account-data.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private apiUrl = 'http://localhost:5131';

  constructor(private httpClient: HttpClient, private tokenService: TokenService, private accountDataService: AccountDataService) {

  }

  register(registerDto: RegisterDto): Observable<string> {
    return this.httpClient.post<string>(this.apiUrl + '/register', registerDto);
  }

  login(loginDto: LoginDto): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>(this.apiUrl + '/login', loginDto);
  }

  logout(): void {
    this.tokenService.removeToken();
    this.accountDataService.setFullName(null);
    this.accountDataService.setLoginStatus(false);
    this.accountDataService.setUserId(null);
  }
}
