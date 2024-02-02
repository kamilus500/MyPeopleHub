import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { TokenService } from '../../services/token.service';
import { Router } from '@angular/router';
import { RegisterDto } from '../../models/RegisterDto';
import { UploadEvent } from 'primeng/fileupload';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.scss'
})
export class RegisterFormComponent {
  registerForm: FormGroup;

  constructor(private accountService: AccountService, private fb: FormBuilder, private router: Router) {
    this.registerForm = this.fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', [Validators.email, Validators.required]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      image: [null, Validators.nullValidator]
    })
  }

  onSubmit() {
    const registerDto: RegisterDto = this.registerForm.value;

    if (registerDto !== undefined || registerDto !== null) {
      this.accountService.register(registerDto)
        .subscribe((response: string) => {
          if (response) {
            this.router.navigate(['/login']);
          }
        })
    }
  }

  onFileSelect(event: any) {
    this.registerForm.patchValue({
      profileImage: event.files[0]
    })
  }
}
