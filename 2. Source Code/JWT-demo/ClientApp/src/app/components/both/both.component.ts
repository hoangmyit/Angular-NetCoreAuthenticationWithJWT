import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/services/admin/admin.service';
import { UserService } from 'src/app/services/user/user.service';
import { ManagerService } from 'src/app/services/manager/manager.service';
import { BothService } from 'src/app/services/both/both.service';
import { NotifierService } from 'angular-notifier';
import { TestModel } from 'src/app/models';

@Component({
  selector: 'app-both',
  templateUrl: './both.component.html',
  styleUrls: ['./both.component.scss']
})
export class BothComponent implements OnInit {
  test: TestModel;
  constructor(
    private _adminService: AdminService,
    private _userService: UserService,
    private _managerService: ManagerService,
    private _bothService: BothService,
    private _notifier: NotifierService,
  ) { }

  ngOnInit() {
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
