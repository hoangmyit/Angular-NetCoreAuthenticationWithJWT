import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLogin, UserToken, TestModel } from './../../models';

@Injectable({
    providedIn: 'root'
})

export class BothService {
    baseUrl = 'api/both';
    constructor(
        private _http: HttpClient,
    ) { }

    Test(): Observable<TestModel> {
        const url = this.baseUrl + '/test';
        const result = this._http.get<TestModel>(url);
        return result;
    }
}
