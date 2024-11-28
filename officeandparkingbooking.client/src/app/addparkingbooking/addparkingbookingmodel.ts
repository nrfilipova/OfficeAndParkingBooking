export class AddParkingBookingModel {
    arrival: Date;
    departure: Date;
    spotId: number;
    registrationPlateId: string;
    carModel?: string;

    constructor(arrival: Date, departure: Date, spotId: number, registrationPlateId: string, carModel?: string){
      this.arrival = arrival;
      this.departure = departure;
      this.spotId = spotId;
      this.registrationPlateId = registrationPlateId;
      this.carModel = carModel;
    }
  }