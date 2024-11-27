import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AddParkingbookingComponent as AddParkingBookingComponent } from './addparkingbooking.component';

describe('AddparkingbookingComponent', () => {
  let component: AddParkingBookingComponent;
  let fixture: ComponentFixture<AddParkingBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddParkingBookingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddParkingBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
