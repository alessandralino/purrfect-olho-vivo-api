import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurrfectDynamicTableComponent } from './purrfect-dynamic-table.component';

describe('PurrfectDynamicTableComponent', () => {
  let component: PurrfectDynamicTableComponent;
  let fixture: ComponentFixture<PurrfectDynamicTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PurrfectDynamicTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurrfectDynamicTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
