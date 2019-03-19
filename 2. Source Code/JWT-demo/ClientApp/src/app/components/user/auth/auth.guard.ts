import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserService } from 'src/app/services/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  _helper = new JwtHelperService();
  constructor(
    private _http: Router,
    private _userService: UserService
  ) { }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (localStorage.getItem('token')) {
      if (!this._helper.isTokenExpired(localStorage.getItem('token'))) {
        const allowRoles = next.data['roles'] as Array<string>;
        if (!allowRoles) {
          return true;
        }
        const result = this._userService.roleMatch(allowRoles);
        if (!result) {
          this._http.navigateByUrl('/unauthorized');
        }
        return result;
      }
      localStorage.removeItem('token');
    }
    this._http.navigateByUrl('/login');
    return false;
  }
}
