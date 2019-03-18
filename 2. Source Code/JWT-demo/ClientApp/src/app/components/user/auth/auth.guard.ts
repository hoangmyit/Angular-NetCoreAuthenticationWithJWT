import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  _helper = new JwtHelperService();
  constructor(
    private _http: Router
  ) { }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (localStorage.getItem('token')) {
      if (this._helper.isTokenExpired(localStorage.getItem('token'))) {
        return true;
      }
      localStorage.removeItem('token');
    }
    this._http.navigateByUrl('/login');
    return false;
  }
}
