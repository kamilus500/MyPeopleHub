import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserDto } from '../../models/UserDto';
import { UserService } from '../user.service';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

    users$: BehaviorSubject<UserDto[]> = new BehaviorSubject<UserDto[]>([]);
    userById$: BehaviorSubject<UserDto | null> = new BehaviorSubject<UserDto | null>(null);

    constructor(private userService: UserService) {
        
    }

    getAllUsers(): Observable<UserDto[]> {
        return this.users$.asObservable();
    }

    loadAllUsers(): void {
        this.userService.getAllUser()
            .subscribe(users => {
                this.users$.next(users);
            })
    }

    loadUserById(userId: string): void {
        this.userService.getUserById(userId)
            .subscribe(user => {
                this.userById$.next(user);
            })
    }
}