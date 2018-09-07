import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

// Models
import { Token } from "../models/token.model";

@Injectable()
export class AuthService {

  constructor(private http: HttpClient) { }

  public GetToken(): Observable<HttpResponse<Token>> {
    return this.http.get<Token>("/token", { observe: 'response' });
  }

}
