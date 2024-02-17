import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.scss'
})
export class RegisterFormComponent {
  registerForm: FormGroup;
  selectedFile: File | null = null;
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
    const registerDto = this.registerForm.value;
    
    if (registerDto !== undefined || registerDto !== null) {
      this.accountService.register(registerDto)
        .subscribe((response: string) => {
          if (response) {
            this.router.navigate(['/login']);
          }
        })
    }
  }

  onFileSelect(event: Event) {
    // this.selectedFile = event.target.files[0];
    // console.log(this.selectedFile);
  }
}
