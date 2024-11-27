export class AddOfficeBookingModel {
    date: Date;
    room: number;
    notes?: string;

    constructor(date: Date, room: number, notes?: string){
      this.date = date;
      this.room = room;
      this.notes = notes;
    }
  }