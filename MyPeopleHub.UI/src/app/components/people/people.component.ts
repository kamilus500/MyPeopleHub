import { Component, OnInit } from '@angular/core';
import { UserDto } from '../../models/UserDto';
import { UserDataService } from '../../services/data-services/user-data.service';
import { Observable, filter } from 'rxjs';
import { FriendshipDataService } from '../../services/data-services/friendship-data.service';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrl: './people.component.scss'
})
export class PeopleComponent implements OnInit {

  users$: Observable<UserDto[]> = this.userDataService.getAllUsers();
  loggedUserId: string;

  constructor(private userDataService: UserDataService, private friendDataService: FriendshipDataService, private router: Router, private tokenService: TokenService) {
    this.loggedUserId = this.tokenService.getUserId() as string;
  }

  ngOnInit(): void {
    this.userDataService.loadAllUsers();
  }

  addFriend(friendId: string): void {
    this.friendDataService.createFriendship(friendId);
  }

  showProfile(userId: string): void {
    this.userDataService.loadUserById(userId);
    this.router.navigate(['/user']);
  }
}
