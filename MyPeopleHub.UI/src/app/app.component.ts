import { AfterContentInit, Component, OnInit } from '@angular/core';
import { TokenService } from './services/token.service';
import { AccountDataService } from './services/data-services/account-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'MyPeopleHub';
  
  constructor(private tokenService: TokenService, private accountDataService: AccountDataService) {

  }

  ngOnInit(): void {
    let fullName = this.tokenService.getFullName()
    let userId = this.tokenService.getUserId();

    this.accountDataService.setFullName(fullName);
    this.accountDataService.setUserId(userId);

    this.accountDataService.setLoginStatus(userId ? true : false);
  }

}
