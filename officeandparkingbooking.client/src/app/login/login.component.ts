import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { FormGroup, FormControl, Validators } from "@angular/forms";

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

  onSubmit(): void{
    const formValues = this.form.value;
    this.loginService.login(formValues).subscribe({ 
      next: (response) => {
      this.form.reset(); 
    }});
  };

  public submitForm(): void {
    this.form.markAllAsTouched();
  }

  public clearForm(): void {
    this.form.reset();
  }
}
