import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

// Models
import { Token } from "../models/token.model";
import { Account } from "../models/account.model";

@Injectable()
export class AuthService {

  constructor(private http: HttpClient) { }

  public GetToken(): Observable<HttpResponse<Token>> {
    return this.http.get<Token>("/account/token", { observe: 'response' });
  }

  public Login(account: Account): Observable<HttpResponse<Account>> {
    return this.http.get<Account>(`/account/login?username=${account.username}&password=${account.password}`, { observe: 'response' });
  }

}
