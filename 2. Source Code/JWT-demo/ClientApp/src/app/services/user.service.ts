import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLogin, UserToken } from '../models';

@Injectable({
    providedIn: 'root'
})

export class UserService {
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
}
