export class AddParkingBookingModel {
    arrival: Date;
    departure: Date;
    spotId: number;
    registrationPlate: string;

    constructor(arrival: Date, departure: Date, spotId: number, registrationPlate: string){
      this.arrival = arrival;
      this.departure = departure;
      this.spotId = spotId;
      this.registrationPlate = registrationPlate;
    }
  }