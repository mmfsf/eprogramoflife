import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthToken } from './auth.token';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    if (AuthToken.isLoggedIn()) {
      return true;
    }

    this.router.navigate(['/login']);
    return false;
  }
}
