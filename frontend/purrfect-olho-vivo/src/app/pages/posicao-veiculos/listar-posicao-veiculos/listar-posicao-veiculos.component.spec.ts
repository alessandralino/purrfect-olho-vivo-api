import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarPosicaoVeiculosComponent } from './listar-posicao-veiculos.component';

describe('ListarPosicaoVeiculosComponent', () => {
  let component: ListarPosicaoVeiculosComponent;
  let fixture: ComponentFixture<ListarPosicaoVeiculosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListarPosicaoVeiculosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListarPosicaoVeiculosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
