import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CriarParadasComponent } from './components/paradas/criar-paradas/criar-paradas.component';
import { ListarParadasComponent } from './components/paradas/listar-paradas/listar-paradas.component';
import { DetalharParadasComponent } from './components/paradas/detalhar-paradas/detalhar-paradas.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { TableGridComponent } from './components/shared/table-grid/table-grid.component';
import { FiltrarParadasComponent } from './components/paradas/filtrar-paradas/filtrar-paradas.component';  
@NgModule({
  declarations: [
    AppComponent,
    CriarParadasComponent,
    ListarParadasComponent,
    DetalharParadasComponent,
    HeaderComponent,
    FooterComponent,
    TableGridComponent,
    FiltrarParadasComponent,  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
