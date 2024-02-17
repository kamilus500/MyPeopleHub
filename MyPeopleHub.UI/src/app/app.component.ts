import { AfterContentInit, Component, OnInit } from '@angular/core';
import { TokenService } from './services/token.service';
import { AccountDataService } from './services/data-services/account-data.service';
import { PropertyEnum } from './enums/PropertyEnum';

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
    let fullName = this.tokenService.getUserProperty(PropertyEnum.Fullname);
    let userId = this.tokenService.getUserProperty(PropertyEnum.UserId);

    this.accountDataService.setFullName(fullName);
    this.accountDataService.setUserId(userId);

    this.accountDataService.setLoginStatus(userId ? true : false);
  }

}
