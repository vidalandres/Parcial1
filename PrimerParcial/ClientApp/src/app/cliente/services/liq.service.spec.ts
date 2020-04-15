import { TestBed } from '@angular/core/testing';

import { LiqService } from './liq.service';

describe('LiqService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LiqService = TestBed.get(LiqService);
    expect(service).toBeTruthy();
  });
});
