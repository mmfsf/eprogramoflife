import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpEvent,
  HttpErrorResponse,
  HttpEventType
} from "@angular/common/http";
import { Observable, of } from "rxjs";
import { tap } from "rxjs/operators";

// Auth
import { AuthToken } from "../auth/auth-token";

@Injectable()
export class HttpBaseInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = req.clone({
      setHeaders: {
        Authorization: AuthToken.GetTokenType() + " " + AuthToken.GetAccessToken()
      }
    });

    return next.handle(req).pipe(
      tap(event => { }, error => { console.log(error); })
    )
  }
}
