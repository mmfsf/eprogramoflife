import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Commitment } from '../models/commitment.model';

@Injectable()
export class CommonService {

  constructor(private http: HttpClient) { }

  public GetCommitments(): Observable<HttpResponse<Array<Commitment>>> {
    return this.http.get<Array<Commitment>>('https://localhost:6001/api/commitments', { observe: 'response' });
  }

  public Point(id: number): Observable<HttpResponse<Commitment>> {
    return this.http.post<Commitment>('https://localhost:6001/api/commitments', {id:id}, { observe: 'response' });
  }

}
