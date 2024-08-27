import { Component, Input, OnInit } from '@angular/core';
import { ParadaService } from '../../../api/services/parada/parada.service';
import { ParadaResponse } from '../../../api/services/parada/response/paradaResponse.model'; 
import { ParadaFiltro } from '../../../api/services/parada/request/paradaRequest.model';
import { PaginationConstants } from '../../../constants/pagination.constants';

@Component({
  selector: 'app-listar-paradas',
  templateUrl: './listar-paradas.component.html',
  styleUrl: './listar-paradas.component.css'
})
export class ListarParadasComponent implements OnInit {
  listaParadas: ParadaResponse[] = [];

  totalItems: number = 0;
  totalPages : number = PaginationConstants.TOTAL_PAGES;
  currentPage: number = PaginationConstants.CURRENT_PAGE;
  pageSize: number = PaginationConstants.PAGE_SIZE;
  filter : ParadaFiltro;

  constructor(private paradaService: ParadaService) {
    this.filter = new ParadaFiltro();
  }

  ngOnInit(): void {  
    this.getAllParadas();
  }

  getAllParadas(filter?: ParadaFiltro) { 
    

    this.filter.pageNumber = this.currentPage;
    this.filter.pageSize = this.pageSize;

    this.paradaService.getAllParadas(filter).subscribe(
      response => {
        this.listaParadas = response.data; 
        this.totalPages = response.pagination.totalPages;
        this.totalItems = response.pagination.totalItems;
        this.currentPage = response.pagination.currentPage;
        this.pageSize = response.pagination.itemsPerPage;
      },
      error => {
        console.error('Erro ao carregar as paradas', error);
        this.listaParadas = [];   
      }
    );
  }
 
  onFilterApplied(filter: ParadaFiltro) {  
    //this.currentPage = 1; 
    this.getAllParadas(filter);
  }

  onPageChanged(page: number) {
    this.currentPage = page;
    this.getAllParadas();
  }
}
