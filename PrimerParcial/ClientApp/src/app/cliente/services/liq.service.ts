import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Liquidacion } from '../models/liquidacion';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../../@base/handle-http-error.service';
import {catchError, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LiqService {

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) 
  {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Liquidacion[]> {
    return this.http.get<Liquidacion[]>('api/liquidacion')
      .pipe(
        tap(_ => this.handleErrorService.log('datos recividos')),
        catchError(this.handleErrorService.handleError<Liquidacion[]>('Consulta Liquidacion', null))
    );
  }
  post(liq: Liquidacion): Observable<Liquidacion> {
    return this.http.post<Liquidacion>(this.baseUrl + 'api/liquidacion', liq)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Liquidacion>('Registrar Liquidacion', null))
    );
  }

}
