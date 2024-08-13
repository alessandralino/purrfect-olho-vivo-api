import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListarParadasComponent } from './components/paradas/listar-paradas/listar-paradas.component';
import { CriarParadasComponent } from './components/paradas/criar-paradas/criar-paradas.component';
import { DetalharParadasComponent } from './components/paradas/detalhar-paradas/detalhar-paradas.component';
import { FiltrarParadasComponent } from './components/paradas/filtrar-paradas/filtrar-paradas.component';

@NgModule({
  declarations: [
    AppComponent,
    ListarParadasComponent,
    CriarParadasComponent,
    DetalharParadasComponent,
    FiltrarParadasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
