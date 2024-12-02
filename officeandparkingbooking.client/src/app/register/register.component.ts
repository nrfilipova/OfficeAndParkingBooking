import { RegisterService } from "./register.service";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { Component, ViewChild } from "@angular/core";
import { TextBoxComponent } from "@progress/kendo-angular-inputs";
import { eyeIcon, SVGIcon } from "@progress/kendo-svg-icons";
import { ITeam } from "./teammodel";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  @ViewChild('password') public textbox!: TextBoxComponent;
  public eyeIcon: SVGIcon = eyeIcon;

  public form: FormGroup = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    fullName : new FormControl('', Validators.required),
    teamId: new FormControl('', Validators.required),
  });
  
  public teams: ITeam[] =[];

  constructor(
    private registerService: RegisterService
  ) {}

  ngOnInit(): void{
    this.loadTeams();
  }

  loadTeams(): void{
    this.registerService.getTeams().subscribe({ 
      next: (data: ITeam[]) => {
        this.teams = data;
      }
    });
  }
  
  public ngAfterViewInit(): void {
    this.textbox.input.nativeElement.type = 'password';
  }

  public toggleVisibility(): void {
    const inputEl = this.textbox.input.nativeElement;
    inputEl.type = inputEl.type === 'password' ? 'text' : 'password';
  }

  onSubmit(): void {
    const formValues = this.form.value;
    this.registerService.register(formValues).subscribe({
      next: () => {
        this.teams = this.teams;
        this.form.reset(); 
        alert("Registration is successfull");
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