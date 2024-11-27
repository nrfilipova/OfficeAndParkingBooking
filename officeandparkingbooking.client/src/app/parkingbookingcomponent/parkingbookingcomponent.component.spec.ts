import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingbookingcomponentComponent as ParkingBookingcomponentComponent } from './parkingbookingcomponent.component';

describe('ParkingbookingcomponentComponent', () => {
  let component: ParkingBookingcomponentComponent;
  let fixture: ComponentFixture<ParkingBookingcomponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ParkingBookingcomponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ParkingBookingcomponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
