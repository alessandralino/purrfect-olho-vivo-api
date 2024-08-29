import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurrfectColumnDynamicTableComponent } from './purrfect-column-dynamic-table.component';

describe('PurrfectColumnDynamicTableComponent', () => {
  let component: PurrfectColumnDynamicTableComponent;
  let fixture: ComponentFixture<PurrfectColumnDynamicTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PurrfectColumnDynamicTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurrfectColumnDynamicTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
