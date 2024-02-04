import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserDto } from '../../models/UserDto';
import { FriendsService } from '../friends.service';
import { TokenService } from '../token.service';
import { CreateFriendship } from '../../models/CreateFriendship';

@Injectable({
  providedIn: 'root'
})
export class FriendshipDataService {

    friends$: BehaviorSubject<UserDto[]> = new BehaviorSubject<UserDto[]>([]);

    constructor(private friendsService: FriendsService, private tokenService: TokenService) {
        
    }

    getAllUsers(): Observable<UserDto[]> {
        return this.friends$.asObservable();
    }

    loadAllUsers(): void {
        let userId = this.tokenService.getUserId();
        this.friendsService.getAllFriends(userId!)
            .subscribe(users => {
                this.friends$.next(users);
            })
    }

    createFriendship(friendId: string) {
        let userId = this.tokenService.getUserId();

        let newFriendship: CreateFriendship = {
            userId: userId as string,
            friendId: friendId
        };

        this.friendsService.createFriend(newFriendship)
            .subscribe((friendshipId) => {
            });
    }
}