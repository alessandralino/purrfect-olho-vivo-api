import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurrfectHeaderComponent } from './purrfect-header.component';

describe('PurrfectHeaderComponent', () => {
  let component: PurrfectHeaderComponent;
  let fixture: ComponentFixture<PurrfectHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PurrfectHeaderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurrfectHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
