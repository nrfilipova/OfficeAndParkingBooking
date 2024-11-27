export class AddOfficeBookingModel {
    fullName: string;
    teamName: string;
    email: string;
    password: string;

    constructor(fullName: string, teamName: string, email: string, password: string){
      this.fullName = fullName;
      this.teamName = teamName;
      this.email = email;
      this.password = password;
    }
  }