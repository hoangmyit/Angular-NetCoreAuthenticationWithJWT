import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';
import { UserLogin, UserToken } from 'src/app/models';
import { NotifierService } from 'angular-notifier';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  fullHeight: string;
  form: FormGroup;
  constructor(
    private _formBuilder: FormBuilder,
    private _userService: UserService,
    private _notifier: NotifierService,
    private _router: Router,
  ) {

   }

  ngOnInit() {
    this.setFullHeight();
    this.form = this._formBuilder.group({
      Password: ['', Validators.required],
      Username: ['', Validators.required]
    });
  }

  get Username() { return this.form.get('Username'); }
  get Password() { return this.form.get('Password'); }

  setFullHeight() {
    this.fullHeight = window.innerHeight + 'px';
  }

  loginUser(info) {
    const userLogin = new UserLogin();
    userLogin.Username = info.Username;
    userLogin.Password = info.Password;
    this._userService.Login(userLogin).subscribe(
      (data: UserToken) => {
        if (data) {
          localStorage.setItem('token', data.Token);
          this._router.navigateByUrl('/home');
        } else {
          this._notifier.notify('warning', 'Your Password or Username is invalid!');
        }
      },
      error => {
        console.log(error);
        this._notifier.notify('error', error.error.Message);
      }
    );
  }
}
