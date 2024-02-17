import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, filter } from 'rxjs';
import { UserDto } from '../../models/UserDto';
import { UserService } from '../user.service';
import { TokenService } from '../token.service';
import { PropertyEnum } from '../../enums/PropertyEnum';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {
    users$: BehaviorSubject<UserDto[]> = new BehaviorSubject<UserDto[]>([]);
    userById$: BehaviorSubject<UserDto | null> = new BehaviorSubject<UserDto | null>(null);

    actuallUserId: string | null = null;

    constructor(private userService: UserService, private tokenService: TokenService) {
        this.actuallUserId = this.tokenService.getUserProperty(PropertyEnum.UserId);
    }

    getAllUsers(): Observable<UserDto[]> {
        return this.users$.asObservable();
    }

    loadAllUsers(): void {
        this.userService.getAllUser()
            .subscribe(users => {
                this.users$.next(users.filter(u => u.id !== this.actuallUserId));
            })
    }

    loadUserById(userId: string): void {
        this.userService.getUserById(userId)
            .subscribe(user => {
                this.userById$.next(user);
            })
    }
}