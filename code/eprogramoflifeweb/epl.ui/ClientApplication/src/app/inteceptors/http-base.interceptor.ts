import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpEvent
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

// Auth
import { AuthToken } from '../auth/auth-token';

@Injectable()
export class HttpBaseInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = req.clone({
      setHeaders: {
        Authorization: AuthToken.GetTokenType() + ' ' + AuthToken.GetAccessToken(),
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      }
    });

    return next.handle(req).pipe(
      tap(event => { }, error => { console.log(error); })
    )
  }
}