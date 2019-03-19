import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLogin, UserToken, TestModel } from './../../models';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})

export class ManagerService {
    baseUrl = 'api/manager';
    constructor(
        private _http: HttpClient,
    ) { }

    Test(): Observable<TestModel> {
        const url = this.baseUrl + '/test';
        const result = this._http.get<TestModel>(url);
        return result;
    }
}
