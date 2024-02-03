import { Component, OnInit } from '@angular/core';
import { UserDto } from '../../models/UserDto';
import { UserDataService } from '../../services/data-services/user-data.service';
import { Observable } from 'rxjs';
import { FriendshipDataService } from '../../services/data-services/friendship-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrl: './people.component.scss'
})
export class PeopleComponent implements OnInit {

  users$: Observable<UserDto[]> = this.userDataService.getAllUsers();

  constructor(private userDataService: UserDataService, private friendDataService: FriendshipDataService, private router: Router) {
    
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
