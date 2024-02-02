import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js'
import { jwtDecode } from 'jwt-decode';
import { CustomJwtPayload } from '../models/CustomJwtPayload';
import { JwtDecryptionService } from './jwt-decryption.service';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private readonly TOKEN_KEY = 'token';

  constructor(private jwtDecodeService: JwtDecryptionService) {
    
  }

  setToken(token: string): void {
    const encryptedValue = this.jwtDecodeService.encrypt(token);
    localStorage.setItem(this.TOKEN_KEY, encryptedValue);
  }

  getToken(): string | null {
    const encryptedValue = localStorage.getItem(this.TOKEN_KEY);

    if(encryptedValue) {
      return this.jwtDecodeService.decrypt(encryptedValue);
    }

    return null;
  }

  getFullName(): string | null {
    const encryptedValue = localStorage.getItem(this.TOKEN_KEY);

    if(encryptedValue) {
      let decryptedValue = this.jwtDecodeService.decrypt(encryptedValue);

      let decoded = jwtDecode<CustomJwtPayload>(decryptedValue);
      return decoded.FullName;
    }

    return null;
  }

  getUserId(): string | null {
    const encryptedValue = localStorage.getItem(this.TOKEN_KEY);

    if(encryptedValue) {
      let decryptedValue = this.jwtDecodeService.decrypt(encryptedValue);
      
      let decoded = jwtDecode<CustomJwtPayload>(decryptedValue);

      return decoded.UserId;
    }

    return null;
  }

  removeToken(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }
}
