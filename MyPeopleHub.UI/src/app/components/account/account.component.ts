import { Component, OnInit, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AccountDataService } from '../../services/data-services/account-data.service';
import { Observable } from 'rxjs';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.scss'
})
export class AccountComponent {
  authItems: MenuItem[] | undefined;

  fullName$: Observable<string | null> = this.dataAccountService.fullName$;
  loginStatus$: Observable<boolean> = this.dataAccountService.loginStatus$;
  
  constructor(private accountService: AccountService, private dataAccountService: AccountDataService) {

    this.authItems = [
      {
        label: 'Login',
        icon: 'pi pi-fw pi-file',
        routerLink: '/login'
      },
      {
        label: 'Register',
        icon: 'pi pi-fw pi-file',
        routerLink: '/register'
      }
    ]
  }

  logout(): void {
    this.accountService.logout();
  }
}
