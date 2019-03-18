import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { formatDate } from '@angular/common';

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
  test = 'demo';
  _jwtHelper = new JwtHelperService();
  constructor(
  ) { }

  ngOnInit() {
    this.test = this._jwtHelper.getTokenExpirationDate(this.token).toDateString();
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
}
