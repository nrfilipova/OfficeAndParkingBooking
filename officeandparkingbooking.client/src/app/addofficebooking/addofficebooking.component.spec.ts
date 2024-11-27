import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AddOfficeBookingComponent } from './addofficebooking.component';

describe('AddofficebookingComponent', () => {
  let component: AddOfficeBookingComponent;
  let fixture: ComponentFixture<AddOfficeBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddOfficeBookingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddOfficeBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
