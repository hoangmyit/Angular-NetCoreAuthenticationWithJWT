import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    _helper = new JwtHelperService();
    constructor(
        private _http: Router
    ) {}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.headers.get('No-Auth')) {
            alert('none required token');
            return next.handle(req);
        }
        const token = localStorage.getItem('token');
        if (token) {
            console.log('pass token');
            if (this._helper.isTokenExpired(token)) {
                const cloneReq = req.clone({
                    headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
                });
                return next.handle(cloneReq).pipe(tap(
                    sucess => {},
                    error => {
                        this._http.navigateByUrl('/unauthorized');
                    }
                ));
            } else {
                localStorage.removeItem('token');
                this._http.navigateByUrl('/login');
            }
        } else {
            this._http.navigateByUrl('/login');
        }
    }

}
