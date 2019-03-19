import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLogin, UserToken, TestModel } from '../../models';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})

export class UserService {
    _jwtHelper = new JwtHelperService();
    baseUrl = 'api/user';
    httpOptions = {
        headers: new HttpHeaders({
            'Accept': '*/*',
            'Content-Type': 'application/json',
        })
    };

    constructor(
        private _http: HttpClient,
    ) { }

    Login(user: UserLogin): Observable<UserToken> {
        const url = this.baseUrl + '/login';
        const header = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'No-Auth': 'True'
            })
        };
        const result = this._http.post<UserToken>(url, user, header);
        return result;
    }

    roleMatch(allowRole: string[]): boolean {
        const token = localStorage.getItem('token');
        let result = false;
        if (token != null) {
            const userRole = this._jwtHelper.decodeToken(token).role;
            allowRole.forEach(element => {
                if (typeof(userRole) === 'string') {
                    if (userRole === element) {
                        result = true;
                    }
                } else {
                    userRole.forEach( x => {
                        if (element === x) {
                         result = true;
                        }
                     });
                }
            });
        }
        return result;
    }

    Test(): Observable<TestModel> {
        const url = this.baseUrl + '/test';
        const result = this._http.get<TestModel>(url);
        return result;
    }
}
