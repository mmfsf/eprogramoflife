import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CommonService {

  constructor(private http: HttpClient) {

  }

  public GetToken(): Observable<HttpResponse<Object>> {
    return this.http.get<Object>('/token', { observe: 'response' });
  }

  public GetIdentity(token): Observable<HttpResponse<Object>> {
    return this.http.get<Object>('https://localhost:44355/api/identity', {
      headers: { 'Authorization':'Bearer ' + token},
      observe: 'response'
    });
  }

  public GetValues(): Observable<HttpResponse<Object>> {
    return this.http.get<Object>('https://localhost:44355/api/values', {
      observe: 'response'
    });
  }

}
