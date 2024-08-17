import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Parada, ParadaFiltro, ParadaResponse } from '../../../api/services/parada/response/paradaResponse.model';
import { ParadaService } from '../../../api/services/parada/parada.service';

@Component({
  selector: 'app-filtrar-paradas',
  templateUrl: './filtrar-paradas.component.html',
  styleUrl: './filtrar-paradas.component.css'
})
export class FiltrarParadasComponent implements OnInit{
  paradaFiltro : ParadaFiltro;
  listaParadas : ParadaResponse[] | undefined;

  @Output() onFilterApplied: EventEmitter<ParadaFiltro> = new EventEmitter<ParadaFiltro>();

  constructor(private paradaService : ParadaService){
    this.paradaFiltro = new ParadaFiltro();
  }

  ngOnInit(): void {
  } 

  filtrarParadas(){
    console.log("Filtrar paradas...", this.paradaFiltro);
    this.onFilterApplied.emit(this.paradaFiltro);
  } 
}
