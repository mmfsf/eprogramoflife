import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Commitment } from '../models/commitment.model';
import { environment } from '../../environments/environment';

@Injectable()
export class CommonService {

  constructor(private http: HttpClient) { }

  public GetCommitments(): Observable<HttpResponse<Array<Commitment>>> {
    return this.http.get<Array<Commitment>>(`${environment.apiUrl}/commitments`, { observe: 'response' });
  }

  public Point(id: number, checked: boolean): Observable<HttpResponse<Commitment>> {
    return this.http.post<Commitment>(`${environment.apiUrl}/commitments`, { id: id, done: checked }, { observe: 'response' });
  }

  public ProgramAll(): Observable<HttpResponse<Object>> {
    return this.http.get<Object>(`${environment.apiUrl}/program/all`, { observe: 'response' });
  }

}
