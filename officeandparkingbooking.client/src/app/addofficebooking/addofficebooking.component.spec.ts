import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOfficebookingComponent } from './addofficebooking.component';

describe('AddofficebookingComponent', () => {
  let component: AddOfficebookingComponent;
  let fixture: ComponentFixture<AddOfficebookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddOfficebookingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddOfficebookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
