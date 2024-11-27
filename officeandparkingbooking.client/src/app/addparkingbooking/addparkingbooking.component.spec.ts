import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddparkingbookingComponent } from './addparkingbooking.component';

describe('AddparkingbookingComponent', () => {
  let component: AddparkingbookingComponent;
  let fixture: ComponentFixture<AddparkingbookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddparkingbookingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddparkingbookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
