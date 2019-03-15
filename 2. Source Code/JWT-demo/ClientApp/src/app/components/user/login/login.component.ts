import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  fullHeight: string;
  constructor() { }

  ngOnInit() {
    this.setFullHeight();
  }

  setFullHeight() {
    this.fullHeight = window.innerHeight + 'px';
  }

  loginUser() {
  }
}
