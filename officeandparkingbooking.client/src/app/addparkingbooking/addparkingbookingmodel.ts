export class AddParkingBookingModel {
    arrival: Date;
    departure: Date;
    spotId: number;
    registrationPlate: string;
    carModel?: string;

    constructor(arrival: Date, departure: Date, spotId: number, registrationPlate: string, carModel?: string){
      this.arrival = arrival;
      this.departure = departure;
      this.spotId = spotId;
      this.registrationPlate = registrationPlate;
      this.carModel = carModel;
    }
  }