import { TestBed } from '@angular/core/testing';

import { OfficeBookingService } from './officebooking.service';

describe('EmployeeService', () => {
  let service: OfficeBookingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OfficeBookingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
