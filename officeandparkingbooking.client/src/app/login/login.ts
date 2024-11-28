export class LoginModel {
    email: string;
    password: string;
    accessToken : string;

    constructor(email: string, password: string, accessToken : string){
      this.email = email;
      this.password = password;
      this.accessToken = accessToken
    }
  }