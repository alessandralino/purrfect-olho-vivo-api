import { Component, OnInit } from '@angular/core';
import { ParadaService } from '../../../api/services/parada/parada.service';
import { ParadaResponse } from '../../../api/services/parada/response/paradaResponse.model'; 
import { ParadaFiltro } from '../../../api/services/parada/request/paradaRequest.model';
import { PaginationConstants } from '../../../constants/pagination.constants';
import { Observable, BehaviorSubject } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-listar-paradas',
  templateUrl: './listar-paradas.component.html',
  styleUrls: ['./listar-paradas.component.css']
})
export class ListarParadasComponent implements OnInit {
  private filterSubject: BehaviorSubject<ParadaFiltro> = new BehaviorSubject(new ParadaFiltro());

  listaParadas$: Observable<ParadaResponse[] | any> | undefined;  
  totalItems: number = 0;
  totalPages: number = PaginationConstants.TOTAL_PAGES;
  currentPage: number = PaginationConstants.CURRENT_PAGE;
  pageSize: number = PaginationConstants.PAGE_SIZE;
 

  constructor(private paradaService: ParadaService) {
    this.getAllParadas();   
  } 
  
  ngOnInit(): void {  
    this.loadFilterParadas(); 
  }

  loadFilterParadas(filter?: ParadaFiltro) { 
    filter = filter || new ParadaFiltro(); 
    this.filterSubject.next(filter); 
  }

  private getAllParadas() {
    this.listaParadas$ = this.filterSubject.asObservable().pipe(
      switchMap(filter => {
        filter.pageNumber = this.currentPage;
        filter.pageSize = this.pageSize;
        return this.paradaService.getAllParadas(filter).pipe(
          map(response => {
            this.formatarPaginacao(response);
            return response.data || [];
          })
        );
      })
    );
  }

  private formatarPaginacao(response: { data: ParadaResponse[]; pagination: any; }) {
    if (response.pagination) {
      this.totalPages = response.pagination.totalPages ?? PaginationConstants.TOTAL_PAGES;
      this.totalItems = response.pagination.totalItems ?? 0;
      this.currentPage = response.pagination.currentPage ?? this.currentPage;
      this.pageSize = response.pagination.itemsPerPage ?? PaginationConstants.PAGE_SIZE;
    }
  }

  onFilterApplied(filter: ParadaFiltro) {  
    this.currentPage = PaginationConstants.CURRENT_PAGE; 
    this.loadFilterParadas(filter);
  }

  onPageChanged(page: number) {
    this.currentPage = page;
    this.loadFilterParadas(); 
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
