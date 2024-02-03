import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../../services/data-services/user-data.service';
import { UserDto } from '../../models/UserDto';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent implements OnInit {
  user: UserDto|null = null;

  constructor(private userDataService: UserDataService) {
    
  }

  ngOnInit(): void {
    this.userDataService.userById$
      .subscribe(user => {
        this.user = user;
      })
  }
}
