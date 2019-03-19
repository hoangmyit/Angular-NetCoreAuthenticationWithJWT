import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestModel } from 'src/app/models';

@Injectable({
    providedIn: 'root'
})

export class AdminService {
    baseUrl = 'api/admin';
    constructor(
        private _http: HttpClient,
    ) { }

    Test(): Observable<TestModel> {
        const url = this.baseUrl + '/test';
        const result = this._http.get<TestModel>(url);
        return result;
    }
}
