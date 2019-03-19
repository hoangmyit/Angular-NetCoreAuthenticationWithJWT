import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { formatDate } from '@angular/common';
import { AdminService } from 'src/app/services/admin/admin.service';
import { UserService } from 'src/app/services/user/user.service';
import { ManagerService } from 'src/app/services/manager/manager.service';
import { BothService } from 'src/app/services/both/both.service';
import { TestModel } from 'src/app/models';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  token = localStorage.getItem('token');
  username: string;
  role: string[];
  dateExpired: Date;
  issuedDate: Date;
  notBeforeDate: Date;
  test: TestModel;
  _jwtHelper = new JwtHelperService();
  constructor(
    private _adminService: AdminService,
    private _userService: UserService,
    private _managerService: ManagerService,
    private _bothService: BothService,
    private _notifier: NotifierService,
  ) { }

  ngOnInit() {
    this.DecodeJWT();
  }

  DecodeJWT() {
    const decode = this._jwtHelper.decodeToken(this.token);
    this.username = decode.unique_name;
    this.role = decode.role;
    this.dateExpired = new Date(formatDate(decode.exp * 1000, 'yyyy-MM-dd HH:mm:ss', 'en-US'));
    this.issuedDate = new Date(formatDate(decode.iat * 1000, 'yyyy-MM-dd HH:mm:ss', 'en-US'));
    this.notBeforeDate = new Date(formatDate(decode.nbf * 1000, 'yyyy-MM-dd HH:mm:ss', 'en-US'));
  }

  TestNormal() {
    this._userService.Test().subscribe(
      (data: TestModel) => {
        this.test = data;
        this._notifier.notify('success', data.Message);
      },
      error => {
        this._notifier.notify('error', error.message);
      }
    );
  }

  TestBoth() {
    this._bothService.Test().subscribe(
      (data: TestModel) => {
        this.test = data;
        this._notifier.notify('success', data.Message);
      },
      error => {
        this._notifier.notify('error', error.message);
      }
    );
  }

  TestManager() {
    this._managerService.Test().subscribe(
      (data: TestModel) => {
        this.test = data;
        this._notifier.notify('success', data.Message);
      },
      error => {
        console.log(error);
        this._notifier.notify('error', error.message);
      }
    );
  }

  TestAdmin() {
    this._adminService.Test().subscribe(
      (data: TestModel) => {
        this.test = data;
        this._notifier.notify('success', data.Message);
      },
      error => {
        this._notifier.notify('error', error.message);
      }
    );
  }
}
