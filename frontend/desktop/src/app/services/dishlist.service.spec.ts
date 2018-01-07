import { TestBed, inject } from '@angular/core/testing';

import { DishlistService } from './dishlist.service';

describe('DishlistService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DishlistService]
    });
  });

  it('should be created', inject([DishlistService], (service: DishlistService) => {
    expect(service).toBeTruthy();
  }));
});
