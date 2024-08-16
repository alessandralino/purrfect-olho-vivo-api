import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurrfectMenuComponent } from './purrfect-menu.component';

describe('PurrfectMenuComponent', () => {
  let component: PurrfectMenuComponent;
  let fixture: ComponentFixture<PurrfectMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PurrfectMenuComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurrfectMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
