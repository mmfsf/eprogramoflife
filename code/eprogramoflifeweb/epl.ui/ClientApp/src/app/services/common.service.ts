import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CommonService {

  constructor(private http: HttpClient) { }

  public GetIdentity(): Observable<HttpResponse<Object>> {
    return this.http.get<Object>('https://localhost:6001/api/identity', {
      observe: 'response'
    });
  }

  public GetValues(): Observable<HttpResponse<Object>> {
    return this.http.get<Object>('https://localhost:6001/api/values', {
      observe: 'response'
    });
  }

}
