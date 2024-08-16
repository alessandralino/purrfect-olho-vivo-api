import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarParadasComponent } from './listar-paradas.component';

describe('ListarParadasComponent', () => {
  let component: ListarParadasComponent;
  let fixture: ComponentFixture<ListarParadasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListarParadasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListarParadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
