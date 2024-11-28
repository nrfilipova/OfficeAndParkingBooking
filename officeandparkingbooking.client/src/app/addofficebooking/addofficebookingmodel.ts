export class AddOfficeBookingModel {
    date: Date;
    roomId: number;
    notes?: string;

    constructor(date: Date, roomId: number, notes?: string){
      this.date = date;
      this.roomId = roomId;
      this.notes = notes;
    }
  }