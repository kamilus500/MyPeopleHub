import { Component, OnInit } from '@angular/core';
import { UserDto } from '../../models/UserDto';
import { UserDataService } from '../../services/data-services/user-data.service';
import { Observable, filter, map } from 'rxjs';
import { FriendshipDataService } from '../../services/data-services/friendship-data.service';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { PropertyEnum } from '../../enums/PropertyEnum';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrl: './people.component.scss'
})
export class PeopleComponent implements OnInit {

  users$: Observable<UserDto[]> = this.userDataService.getAllUsers();;
  users: UserDto[] = [];
  loggedUserId: string;
  searchedText: string = '';

  constructor(private userDataService: UserDataService, private friendDataService: FriendshipDataService, private router: Router, private tokenService: TokenService) {
    this.loggedUserId = this.tokenService.getUserProperty(PropertyEnum.UserId) as string;
    this.userDataService.loadAllUsers();
  }

  ngOnInit(): void {
    this.users$.subscribe((users: UserDto[]) => {
      this.users = users;
    })
  }

  onModelChange(searchedText: string) {
    searchedText === '' 
      ? this.userDataService.loadAllUsers() 
      : this.users = this.users = this.users.filter(u => u.fullName.includes(searchedText));
  }

  addFriend(friendId: string): void {
    this.friendDataService.createFriendship(friendId);

    setTimeout(() => {
      this.router.navigate(['/friends']);
    }, 2000);
  }

  showProfile(userId: string): void {
    this.userDataService.loadUserById(userId);
    this.router.navigate(['/user']);
  }
}
