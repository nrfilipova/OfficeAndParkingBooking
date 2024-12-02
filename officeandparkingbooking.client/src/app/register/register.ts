export class RegisterModel {
    email: string;
    password: string;
    fullName : string;
    teamId : number;

    constructor(email: string, password: string, fullName : string,  teamId : number){
      this.email = email;
      this.password = password;
      this.fullName = fullName;
      this.teamId = teamId;
    }
  }