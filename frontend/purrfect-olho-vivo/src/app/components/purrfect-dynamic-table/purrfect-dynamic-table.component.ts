import { Component, ContentChildren, QueryList, Input, AfterContentInit } from '@angular/core';
import { PurrfectColumnDynamicTableComponent } from '../purrfect-column-dynamic-table/purrfect-column-dynamic-table.component';

@Component({
  selector: 'app-purrfect-dynamic-table',
  templateUrl: './purrfect-dynamic-table.component.html',
})
export class PurrfectDynamicTableComponent implements AfterContentInit {
  @Input() data: Array<any> = [];

  @ContentChildren(PurrfectColumnDynamicTableComponent) columns!: QueryList<PurrfectColumnDynamicTableComponent>;

  ngAfterContentInit() {
     
  }
}
