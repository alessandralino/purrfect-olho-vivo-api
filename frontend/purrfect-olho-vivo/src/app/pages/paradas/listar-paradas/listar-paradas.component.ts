import { Component, Input, OnInit } from '@angular/core';
import { ParadaService } from '../../../api/services/parada/parada.service';
import { ParadaResponse } from '../../../api/services/parada/response/paradaResponse.model'; 
import { ParadaFiltro } from '../../../api/services/parada/request/paradaRequest.model';

@Component({
  selector: 'app-listar-paradas',
  templateUrl: './listar-paradas.component.html',
  styleUrl: './listar-paradas.component.css'
})
export class ListarParadasComponent implements OnInit{
  
  listaParadas : ParadaResponse[] | undefined;
  constructor(private paradaService : ParadaService){}

  ngOnInit(): void {  
    this.getAllParadas();
  }

  getAllParadas(filter?: ParadaFiltro) { 
    this.paradaService.getAllParadas(filter).subscribe(
      data => {
        this.listaParadas = data;
      },
      error => {
        console.error('Erro ao carregar as paradas', error);
        this.listaParadas = [];   
      }
    );
  }
 
  onFilterApplied(filter: ParadaFiltro) {  
    this.getAllParadas(filter);
  }
}
