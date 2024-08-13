import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarParadasComponent } from './criar-paradas.component';

describe('CriarParadasComponent', () => {
  let component: CriarParadasComponent;
  let fixture: ComponentFixture<CriarParadasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CriarParadasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CriarParadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
