import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Parada, ParadaResponse } from '../../../api/services/parada/response/paradaResponse.model';
import { ParadaService } from '../../../api/services/parada/parada.service';
import { ParadaFiltro } from '../../../api/services/parada/request/paradaRequest.model';

@Component({
  selector: 'app-filtrar-paradas',
  templateUrl: './filtrar-paradas.component.html',
  styleUrl: './filtrar-paradas.component.css'
})
export class FiltrarParadasComponent implements OnInit
{
  paradaFiltro : ParadaFiltro;
  listaParadas : ParadaResponse[] | undefined;

  @Output() onFilterApplied: EventEmitter<ParadaFiltro> = new EventEmitter<ParadaFiltro>();

  constructor(private paradaService : ParadaService)
  {
    this.paradaFiltro = new ParadaFiltro();
  }

  ngOnInit(): void 
  {  } 

  filtrarParadas()
  { 
    this.onFilterApplied.emit(this.paradaFiltro);
  } 

  limparFiltros()
  {
    this.instanciarParadaFiltro();
    this.filtrarParadas();
  }

  private instanciarParadaFiltro() 
  {
    this.paradaFiltro = new ParadaFiltro();
  }
}
