import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent implements OnInit {
  token = localStorage.getItem('token');

  constructor(
    private _router: Router,
  ) { }

  ngOnInit() {
  }
  LogOut() {
    localStorage.removeItem('token');
    this._router.navigateByUrl('/login');
  }
}
