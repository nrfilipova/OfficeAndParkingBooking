export class AddParkingBookingModel {
    arrival: Date;
    departure: Date;
    parkingSpot: number;
    registrationPlate: string;
    carModel?: string;

    constructor(arrival: Date, departure: Date, parkingSpot: number, registrationPlate: string, carModel?: string){
      this.arrival = arrival;
      this.departure = departure;
      this.parkingSpot = parkingSpot;
      this.registrationPlate = registrationPlate;
      this.carModel = carModel;
    }
  }