import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PurrfectFooterComponent } from './components/purrfect-footer/purrfect-footer.component';
import { PurrfectHeaderComponent } from './components/purrfect-header/purrfect-header.component';
import { PurrfectHomeComponent } from './components/purrfect-home/purrfect-home.component';
import { PurrfectMenuComponent } from './components/purrfect-menu/purrfect-menu.component';
import { CriarParadasComponent } from './pages/paradas/criar-paradas/criar-paradas.component';
import { DetalharParadasComponent } from './pages/paradas/detalhar-paradas/detalhar-paradas.component';
import { FiltrarParadasComponent } from './pages/paradas/filtrar-paradas/filtrar-paradas.component';
import { ListarParadasComponent } from './pages/paradas/listar-paradas/listar-paradas.component';
import { ListarVeiculosComponent } from './pages/veiculos/listar-veiculos/listar-veiculos.component';
import { ListarLinhasComponent } from './pages/linhas/listar-linhas/listar-linhas.component';
import { ListarPosicaoVeiculosComponent } from './pages/posicao-veiculos/listar-posicao-veiculos/listar-posicao-veiculos.component';
import { HttpClientModule } from '@angular/common/http';
import { PurrfectPaginationComponent } from './components/purrfect-pagination/purrfect-pagination.component';
import { PurrfectDynamicTableComponent } from './components/purrfect-dynamic-table/purrfect-dynamic-table.component';
import { PurrfectColumnDynamicTableComponent } from './components/purrfect-column-dynamic-table/purrfect-column-dynamic-table.component';



@NgModule({
  declarations: [
    AppComponent,
    ListarParadasComponent,
    CriarParadasComponent,
    DetalharParadasComponent,
    FiltrarParadasComponent,
    PurrfectFooterComponent,
    PurrfectHeaderComponent,
    PurrfectMenuComponent,
    PurrfectHomeComponent,
    ListarVeiculosComponent,
    ListarLinhasComponent,
    ListarPosicaoVeiculosComponent,
    PurrfectPaginationComponent,
    PurrfectDynamicTableComponent,
    PurrfectColumnDynamicTableComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
