import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltrarParadasComponent } from './filtrar-paradas.component';

describe('FiltrarParadasComponent', () => {
  let component: FiltrarParadasComponent;
  let fixture: ComponentFixture<FiltrarParadasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FiltrarParadasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltrarParadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
