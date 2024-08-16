import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurrfectHomeComponent } from './purrfect-home.component';

describe('PurrfectHomeComponent', () => {
  let component: PurrfectHomeComponent;
  let fixture: ComponentFixture<PurrfectHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PurrfectHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurrfectHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
