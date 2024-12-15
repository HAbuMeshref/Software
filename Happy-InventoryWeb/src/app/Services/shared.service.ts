import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ResponseResult, SelectItem } from '../Models/models';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private apiUrl = environment.apiUrl + 'api/';
    private httpHeaders = new HttpHeaders().set('Accept', 'application/json').set('Access-Control-Allow-Origin', '*').set('content-type', 'application/json; charset=utf-8');
  
  constructor(private http: HttpClient) { }


  GetAllLookupDetails(lookupCode:number): Observable<ResponseResult<SelectItem>> {
          return this.http.get<ResponseResult<SelectItem[]>>(this.apiUrl + 'LookupDetails/GetBylookupCode?lookupCode=' + lookupCode,
            { headers: this.httpHeaders, responseType: 'json' }).pipe(
            catchError(err => {
              return throwError(err);
            })
          );
        }
}
