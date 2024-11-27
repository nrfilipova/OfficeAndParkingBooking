import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddofficebookingComponent } from './addofficebooking.component';

describe('AddofficebookingComponent', () => {
  let component: AddofficebookingComponent;
  let fixture: ComponentFixture<AddofficebookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddofficebookingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddofficebookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
