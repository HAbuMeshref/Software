import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ResponseResult, warehouse } from '../Models/models';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  private apiUrl = environment.apiUrl + 'api/';
    private httpHeaders = new HttpHeaders().set('Accept', 'application/json').set('Access-Control-Allow-Origin', '*').set('content-type', 'application/json; charset=utf-8');
  
  constructor(private http: HttpClient) { }


    Add(warehouse: warehouse): Observable<ResponseResult<warehouse>> {
        return this.http.post<ResponseResult<warehouse>>(this.apiUrl + 'Warehouse', warehouse, { headers: this.httpHeaders, responseType: 'json' }).pipe(
          catchError(err => {
            return throwError(err);
          })
        );
      }

      // GetAll(warehouse: warehouse): Observable<ResponseResult<warehouse>> {
      //   return this.http.post<ResponseResult<warehouse>>(this.apiUrl + 'Warehouse', warehouse, { headers: this.httpHeaders, responseType: 'json' }).pipe(
      //     catchError(err => {
      //       return throwError(err);
      //     })
      //   );
      // }

  GetAllwarehouse(): Observable<ResponseResult<warehouse[]>> {
        return this.http.get<ResponseResult<warehouse[]>>(this.apiUrl + 'Warehouse', { headers: this.httpHeaders, responseType: 'json' }).pipe(
          catchError(err => {
            return throwError(err);
          })
        );
      }
}
