import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Login, ResponseResult, warehouse } from '../Models/models';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl = environment.apiUrl + 'api/';
    private httpHeaders = new HttpHeaders().set('Accept', 'application/json').set('Access-Control-Allow-Origin', '*').set('content-type', 'application/json; charset=utf-8');
  
  constructor(private http: HttpClient) { }


  Login(lgoin: Login): Observable<Login> {
      return this.http.post<Login>(this.apiUrl + 'Users/Login', lgoin, { headers: this.httpHeaders, responseType: 'json' }).pipe(
        catchError(err => {
          return throwError(err);
        })
      );
    }
}
