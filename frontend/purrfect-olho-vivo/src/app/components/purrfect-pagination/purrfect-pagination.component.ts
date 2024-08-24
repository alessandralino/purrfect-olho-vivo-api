import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PaginationConstants } from '../../constants/pagination.constants';

@Component({
  selector: 'app-purrfect-pagination',
  templateUrl: './purrfect-pagination.component.html',
  styleUrl: './purrfect-pagination.component.css'
})
export class PurrfectPaginationComponent {
  @Input() totalPages: number = PaginationConstants.PAGE_NUMBER;
  @Input() currentPage: number = PaginationConstants.PAGE_SIZE;
  @Output() pageChanged = new EventEmitter<number>();

  get pages(): number[] {
    const pages: number[] = [];
    const maxPagesToShow = 3;
    
    if (this.totalPages <= maxPagesToShow + 2) {
      for (let i = 1; i <= this.totalPages; i++) {
        pages.push(i);
      }
    } else {
      pages.push(1);
      if (this.currentPage > 2) {
        pages.push(this.currentPage - 1);
      }
      if (this.currentPage > 1 && this.currentPage < this.totalPages) {
        pages.push(this.currentPage);
      }
      if (this.currentPage < this.totalPages - 1) {
        pages.push(this.currentPage + 1);
      }
      pages.push(this.totalPages);
    }

    return pages;
  }

  onPageClick(page: number) {
    if (page !== this.currentPage) {
      this.currentPage = page;
      this.pageChanged.emit(this.currentPage);
    }
  }
}
