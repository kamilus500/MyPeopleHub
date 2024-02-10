import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../../services/data-services/user-data.service';
import { UserDto } from '../../models/UserDto';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent{
  user: UserDto|null = null;
  user$: Observable<UserDto|null> = this.userDataService.userById$;

  constructor(private userDataService: UserDataService) {
    
  }
}
