import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginDto } from '../../models/LoginDto';
import { TokenService } from '../../services/token.service';
import { LoginResponse } from '../../models/LoginResponse';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AccountDataService } from '../../services/data-services/account-data.service';
import { PropertyEnum } from '../../enums/PropertyEnum';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss'
})
export class LoginFormComponent {

  loginForm: FormGroup;

  constructor(private accountService: AccountService, 
              private accountDataService: AccountDataService,
              private fb: FormBuilder, 
              private tokenService: TokenService, 
              private router: Router
  ) {
    this.loginForm = this.fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onSubmit() {
    const loginDto: LoginDto = this.loginForm.value;

    if (loginDto !== undefined || loginDto !== null) {
      this.accountService.login(loginDto)
        .subscribe((response: LoginResponse) => {
          if (response.token) {
            this.tokenService.setToken(response.token);
            
            let fullName = this.tokenService.getUserProperty(PropertyEnum.Fullname);
            let userId = this.tokenService.getUserProperty(PropertyEnum.UserId);

            this.accountDataService.setFullName(fullName);
            this.accountDataService.setUserId(userId);
            this.accountDataService.setLoginStatus(true);

            this.router.navigate(['/friends']);
          }
        })
    }
  }
}
