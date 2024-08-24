import { PaginationConstants } from "../../../../constants/pagination.constants";

export class PaginationFilter {
    pageSize : number;
    pageNumber: number; 
   
   constructor(){
    this.pageNumber = PaginationConstants.PAGE_NUMBER;
    this.pageSize = PaginationConstants.PAGE_SIZE;
   }
  }