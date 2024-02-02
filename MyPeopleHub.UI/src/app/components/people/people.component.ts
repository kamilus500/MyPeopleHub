import { Component, OnInit } from '@angular/core';
import { UserDto } from '../../models/UserDto';
import { UserDataService } from '../../services/data-services/user-data.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrl: './people.component.scss'
})
export class PeopleComponent implements OnInit {

  users$: Observable<UserDto[]> = this.userDataService.getAllUsers();

  constructor(private userDataService: UserDataService) {
    
  }

  ngOnInit(): void {
    this.userDataService.loadAllUsers();
  }
}
