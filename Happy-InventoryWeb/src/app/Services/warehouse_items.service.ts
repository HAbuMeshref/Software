import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ResponseResult, warehouse, WarehouseItem } from '../Models/models';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WarehouseItemsService {
  private apiUrl = environment.apiUrl + 'api/';
    private httpHeaders = new HttpHeaders().set('Accept', 'application/json').set('Access-Control-Allow-Origin', '*').set('content-type', 'application/json; charset=utf-8');
  
  constructor(private http: HttpClient) { }


    Add(warehouse: WarehouseItem): Observable<ResponseResult<WarehouseItem>> {
        return this.http.post<ResponseResult<WarehouseItem>>(this.apiUrl + 'WarehouseItemItem', warehouse, { headers: this.httpHeaders, responseType: 'json' }).pipe(
          catchError(err => {
            return throwError(err);
          })
        );
      }

  GetAllwarehouse(): Observable<ResponseResult<WarehouseItem[]>> {
        return this.http.get<ResponseResult<WarehouseItem[]>>(this.apiUrl + 'WarehouseItemItem', { headers: this.httpHeaders, responseType: 'json' }).pipe(
          catchError(err => {
            return throwError(err);
          })
        );
      }

      GetItemByWarehouseID(warehouseId?:string): Observable<ResponseResult<WarehouseItem[]>> {
        return this.http.get<ResponseResult<WarehouseItem[]>>(this.apiUrl + 'WarehouseItemItem/GetByWarehouseId?warehouseId=' + warehouseId
          
          , { headers: this.httpHeaders, responseType: 'json' }).pipe(
          catchError(err => {
            return throwError(err);
          })
        );
      }
}
