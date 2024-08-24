import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurrfectPaginationComponent } from './purrfect-pagination.component';

describe('PurrfectPaginationComponent', () => {
  let component: PurrfectPaginationComponent;
  let fixture: ComponentFixture<PurrfectPaginationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PurrfectPaginationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurrfectPaginationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
