import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurrfectFooterComponent } from './purrfect-footer.component';

describe('PurrfectFooterComponent', () => {
  let component: PurrfectFooterComponent;
  let fixture: ComponentFixture<PurrfectFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PurrfectFooterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurrfectFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
