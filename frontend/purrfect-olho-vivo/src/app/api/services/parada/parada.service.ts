import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { ParadaResponse } from './response/paradaResponse.model';
import { catchError, map, Observable, of } from 'rxjs';
import { ParadaFiltro } from './request/paradaRequest.model';

@Injectable({
  providedIn: 'root'
})
export class ParadaService {
  private url = environment.apiUrl + "api/Parada";

  constructor(private http: HttpClient) { }

  getAllParadas(filter?: ParadaFiltro): Observable<{ data: ParadaResponse[], pagination: any }> {
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
      if (filter.pageNumber) {
        params = params.set('pageNumber', filter.pageNumber.toString());
      }
      if (filter.pageSize) {
        params = params.set('pageSize', filter.pageSize.toString());
      } 
    } else {
      filter = new ParadaFiltro();
      params = params.set('pageNumber', filter.pageNumber.toString());
      params = params.set('pageSize', filter.pageSize.toString());
    }

    return this.http.get<ParadaResponse[]>(this.url, { params: params, observe: 'response' }).pipe(
      map((response: HttpResponse<ParadaResponse[]>) => {
        const pagination = JSON.parse(response.headers.get('pagination') || '{}');
        return { data: response.body || [], pagination: pagination };
      }),
      catchError(error => {
        if (error.status === 404) {
          return of({ data: [], pagination: {} });
        } else {
          throw error;
        }
      })
    );
  }
}
