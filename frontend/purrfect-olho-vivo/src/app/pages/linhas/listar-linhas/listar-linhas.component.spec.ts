import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarLinhasComponent } from './listar-linhas.component';

describe('ListarLinhasComponent', () => {
  let component: ListarLinhasComponent;
  let fixture: ComponentFixture<ListarLinhasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListarLinhasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListarLinhasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
