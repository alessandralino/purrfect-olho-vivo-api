import { PaginationFilter } from "./paginationFilter.model";

export class ParadaFiltro extends PaginationFilter{
    id? : number;
    nome?: string;
    latitude?: string;
    longitude?: string;
  
    constructor( ){
        super();
    }  
  }