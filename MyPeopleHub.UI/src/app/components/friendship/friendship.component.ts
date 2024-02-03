import { Component } from '@angular/core';
import { FriendshipDataService } from '../../services/data-services/friendship-data.service';
import { Observable } from 'rxjs';
import { UserDto } from '../../models/UserDto';

@Component({
  selector: 'app-friendship',
  templateUrl: './friendship.component.html',
  styleUrl: './friendship.component.scss'
})
export class FriendshipComponent {
  friends$: Observable<UserDto[]> = this.friendshipDataService.getAllUsers();

  constructor(private friendshipDataService: FriendshipDataService) {
    this.friendshipDataService.loadAllUsers();
  }

}