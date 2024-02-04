import { Component } from '@angular/core';
import { FriendshipDataService } from '../../services/data-services/friendship-data.service';
import { Observable } from 'rxjs';
import { UserDto } from '../../models/UserDto';
import { UserDataService } from '../../services/data-services/user-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-friendship',
  templateUrl: './friendship.component.html',
  styleUrl: './friendship.component.scss'
})
export class FriendshipComponent {
  friends$: Observable<UserDto[]> = this.friendshipDataService.getAllUsers();

  constructor(private friendshipDataService: FriendshipDataService, private userDataService: UserDataService, private router: Router) {
    this.friendshipDataService.loadAllUsers();
  }

  showProfile(userId: string): void {
    this.userDataService.loadUserById(userId);
    this.router.navigate(['/user']);
  }

}