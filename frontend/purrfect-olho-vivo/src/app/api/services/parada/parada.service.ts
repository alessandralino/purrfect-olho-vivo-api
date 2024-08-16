import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ParadaResponse } from './response/paradaResponse.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ParadaService {
  private url = environment.apiUrl + "api/Parada";

  constructor(private http: HttpClient) { }

  getAllParadas() : Observable<ParadaResponse[]> {
    return this.http.get<ParadaResponse[]>(this.url);
  }
}
