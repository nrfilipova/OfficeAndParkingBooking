import { LoginService } from './login.service';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { LoginModel } from './login';
import { Component, ViewChild } from "@angular/core";
import { TextBoxComponent } from "@progress/kendo-angular-inputs";
import { eyeIcon, SVGIcon } from "@progress/kendo-svg-icons";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  @ViewChild('password') public textbox!: TextBoxComponent;
  public eyeIcon: SVGIcon = eyeIcon;

  public form: FormGroup = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });
  
  constructor(
    private loginService: LoginService
  ) {}

  public ngAfterViewInit(): void {
    this.textbox.input.nativeElement.type = 'password';
  }

  public toggleVisibility(): void {
    const inputEl = this.textbox.input.nativeElement;
    inputEl.type = inputEl.type === 'password' ? 'text' : 'password';
  }

  onSubmit(): void {
    const formValues = this.form.value;
    this.loginService.login(formValues).subscribe({
      next: (response: LoginModel) => {
        if (response.accessToken) {
          localStorage.setItem('accessToken', response.accessToken);
        }
        alert("You are logged in :)");
        this.form.reset();
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
