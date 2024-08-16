import { Component, OnInit } from '@angular/core';
import { ParadaService } from '../../../api/services/parada/parada.service';
import { ParadaResponse } from '../../../api/services/parada/response/paradaResponse.model';

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

  getAllParadas(){
    this.paradaService.getAllParadas().subscribe(data => { 
      console.log("Lista de Paradas:", data);
      this.listaParadas = data;
     });
  }
}
