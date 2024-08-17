import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ParadaFiltro, ParadaResponse } from './response/paradaResponse.model';
import { catchError, Observable, of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ParadaService {
  private url = environment.apiUrl + "api/Parada";

  constructor(private http: HttpClient) { }

   getAllParadas(filter?: ParadaFiltro): Observable<ParadaResponse[]> {
    let params = new HttpParams();

    if (filter) {
      if (filter.id) {
        params = params.set('Id', filter.id.toString());
      }
      if (filter.nome) {
        params = params.set('Name', filter.nome);
      }
      if (filter.latitude) {
        params = params.set('Latitude', filter.latitude.toString());
      }
      if (filter.longitude) {
        params = params.set('Longitude', filter.longitude.toString());
      }
    }

    return this.http.get<ParadaResponse[]>(this.url, { params: params }).pipe(
      catchError(error => {
        if (error.status === 404) {
          // Retorna uma lista vazia em caso de erro 404
          return of([]);
        } else {
          // Re-throw the error if it's not a 404
          throw error;
        }
      })
    );
  }
}
