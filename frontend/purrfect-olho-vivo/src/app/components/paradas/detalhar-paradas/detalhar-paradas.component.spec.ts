import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalharParadasComponent } from './detalhar-paradas.component';

describe('DetalharParadasComponent', () => {
  let component: DetalharParadasComponent;
  let fixture: ComponentFixture<DetalharParadasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetalharParadasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetalharParadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
