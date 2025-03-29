import { TestBed } from '@angular/core/testing';

import { WorldStatsService } from './world-stats.service';

describe('WorldStatsService', () => {
  let service: WorldStatsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorldStatsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
