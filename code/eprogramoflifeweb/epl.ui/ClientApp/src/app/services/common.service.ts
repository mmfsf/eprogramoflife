import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CommonService {

  constructor(private http: HttpClient) { }

  public GetCommitments(): Observable<HttpResponse<Object>> {
    return this.http.get<Object>('https://localhost:6001/api/commitments', { observe: 'response' });
  }

  public Point(): Observable<HttpResponse<Object>> {
    return this.http.post('https://localhost:6001/api/commitments', {}, { observe: 'response' });
  }

}
