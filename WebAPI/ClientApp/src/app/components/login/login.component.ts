import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { UserLoginModel } from '@models';
import { Select, Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { UserManagementActions } from 'src/app/ngxs-store/user-management/user-management.action';
import { UserManagementSelector } from 'src/app/ngxs-store/user-management/user-management.selector';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  @Select(UserManagementSelector.formLoading) loading$: Observable<boolean> | undefined;
  hide = false;
  loginForm = this.fb.group({
    username: ['', [Validators.required]],
    password: ['', [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(30)
    ]]
  });

  constructor(
    private fb: FormBuilder,
    private store: Store,
    private dialog: MatDialog
  ) { }

  close() {
    this.dialog.closeAll();
  }

  save() {
    const model = new UserLoginModel();
    model.userName = this.getValueFromform('username');
    model.password = this.getValueFromform('password');
    this.store.dispatch(new UserManagementActions.Login(model)).subscribe(res => {
      this.dialog.closeAll();
    });
  }

  getValueFromform(val: string) {
    return this.loginForm.get(val)?.value;
  }


}
