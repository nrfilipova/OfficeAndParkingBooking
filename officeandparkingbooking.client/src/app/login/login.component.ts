import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { LoginModel } from './login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  public form: FormGroup = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });
  
  constructor(
    private loginService: LoginService
  ) {}

  onSubmit(): void {
    const formValues = this.form.value;
    this.loginService.login(formValues).subscribe({
      next: (response: LoginModel) => {
        if (response.accessToken) {
          localStorage.setItem('accessToken', response.accessToken);
        }
        alert("You are logged in :)");
        this.form.reset();
      },
      error: (err) => {
        console.error('Login error:', err);
      }
    });
  }

  public submitForm(): void {
    this.form.markAllAsTouched();
  }

  public clearForm(): void {
    this.form.reset();
  }
}
