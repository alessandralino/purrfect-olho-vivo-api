import { Component, Input, TemplateRef, ContentChild } from '@angular/core';

@Component({
  selector: 'app-purrfect-column-dynamic-table',
  templateUrl: './purrfect-column-dynamic-table.component.html',
})
export class PurrfectColumnDynamicTableComponent {
  @Input() header!: string;
  @Input() field?: string;  
  
  // Captura o template que pode ser passado dentro do conteúdo
  @ContentChild(TemplateRef) template!: TemplateRef<any>;
}
