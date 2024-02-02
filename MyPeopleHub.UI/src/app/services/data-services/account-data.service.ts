import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountDataService {

    loginStatus$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    fullName$: BehaviorSubject<string|null> = new BehaviorSubject<string|null>(null);
    userId$: BehaviorSubject<string|null> = new BehaviorSubject<string|null>(null);

    setLoginStatus(status: boolean): void {
        this.loginStatus$.next(status);
    }

    setFullName(fullName: string|null): void {
        this.fullName$.next(fullName);
    }

    setUserId(userId: string|null): void {
        this.userId$.next(userId);
    }

    getUserId(): Observable<string|null> {
        return this.userId$.asObservable();
    }

    getFullName():  Observable<string|null> {
        return this.fullName$.asObservable();
    }

    getLoginStatus(): Observable<boolean> {
        return this.loginStatus$.asObservable();
    }
}