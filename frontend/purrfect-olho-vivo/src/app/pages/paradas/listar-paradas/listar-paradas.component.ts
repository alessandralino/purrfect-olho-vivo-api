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
  
 
  constructor(private paradaService: ParadaService) {}

  ngOnInit(): void {  
    this.getAllParadas();
  }

  getAllParadas(filter?: ParadaFiltro) { 
    filter = filter || new ParadaFiltro(); 
    filter.pageNumber = this.currentPage;
    filter.pageSize = this.pageSize;

    this.paradaService.getAllParadas(filter).subscribe(
      response => {
        this.listaParadas = response.data;  

        this.formatarPaginação(response);  
        
      },
      error => {
        console.error('Erro ao carregar as paradas', error);
        this.listaParadas = [];   
      }
    );
  }
 
  private formatarPaginação(response: { data: ParadaResponse[]; pagination: any; }) {
    if (response.pagination) {
      this.totalPages = response.pagination.totalPages ?? PaginationConstants.TOTAL_PAGES;
      this.totalItems = response.pagination.totalItems ?? 0;
      this.currentPage = response.pagination.currentPage ?? this.currentPage;
      this.pageSize = response.pagination.itemsPerPage ?? PaginationConstants.PAGE_SIZE;
    }
  }

  onFilterApplied(filter: ParadaFiltro) {  
    this.currentPage = PaginationConstants.CURRENT_PAGE; 
    this.getAllParadas(filter);
  }

  onPageChanged(page: number) {
    this.currentPage = page;
    this.getAllParadas();
  }

  view(_t16: any) {
    throw new Error('Method not implemented.');
  }

  delete(_t16: any) {
  throw new Error('Method not implemented.');
  }
  
  edit(_t16: any) {
  throw new Error('Method not implemented.');
  }
}
