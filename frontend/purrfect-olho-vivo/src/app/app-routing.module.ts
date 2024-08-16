import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarParadasComponent } from './pages/paradas/listar-paradas/listar-paradas.component';
import { ListarVeiculosComponent } from './pages/veiculos/listar-veiculos/listar-veiculos.component';
import { ListarLinhasComponent } from './pages/linhas/listar-linhas/listar-linhas.component';
import { ListarPosicaoVeiculosComponent } from './pages/posicao-veiculos/listar-posicao-veiculos/listar-posicao-veiculos.component';

const routes: Routes = [
  { path: 'paradas', component: ListarParadasComponent }, 
  { path: 'veiculos', component: ListarVeiculosComponent }, 
  { path: 'linhas', component: ListarLinhasComponent }, 
  { path: 'posicao-veiculo', component: ListarPosicaoVeiculosComponent }, 
  { path: '', redirectTo: '/paradas', pathMatch: 'full' }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
