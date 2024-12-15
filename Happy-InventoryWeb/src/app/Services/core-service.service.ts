import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseResult, User } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class CoreServiceService {
  private apiUrl = environment.apiUrl + 'api/';
    private httpHeaders = new HttpHeaders().set('Accept', 'application/json').set('Access-Control-Allow-Origin', '*').set('content-type', 'application/json; charset=utf-8');
  
  constructor(private http: HttpClient) { }


  AddUser(user: User): Observable<ResponseResult<User>> {
    return this.http.post<ResponseResult<User>>(this.apiUrl + 'Users', user, { headers: this.httpHeaders, responseType: 'json' }).pipe(
      catchError(err => {
        return throwError(err);
      })
    );
  }
}
