import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { UserRegisterModel } from '@models';
import { Select, Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { UserManagementActions } from 'src/app/ngxs-store/user-management/user-management.action';
import { UserManagementSelector } from 'src/app/ngxs-store/user-management/user-management.selector';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  @Select(UserManagementSelector.formLoading) loading$: Observable<boolean> | undefined;
  hide = false;

  addForm = this.fb.group({
    userName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
    phoneNumber: ['', [Validators.minLength(10), Validators.maxLength(12), Validators.pattern(/^\d{10,12}$/)]],
    dateOfBirth: ['', [Validators.required]]
  });

  constructor(
    private fb: FormBuilder,
    private store: Store,
    private dialog: MatDialog
  ) { }

  saveUser() {
    const model = new UserRegisterModel();
    model.email = this.getValueFromform('email');
    model.username = this.getValueFromform('userName');
    model.firstName = this.getValueFromform('firstName');
    model.lastName = this.getValueFromform('lastName');
    model.password = this.getValueFromform('password');
    model.phoneNumber = this.getValueFromform('phoneNumber');
    model.dateOfBirth = this.getValueFromform('dateOfBirth');
    console.warn(model);
    this.store.dispatch(new UserManagementActions.Register(model)).subscribe(res => {
      this.dialog.closeAll();
    }, err =>  {
      this.dialog.closeAll();
    });
  }

  getValueFromform(val: string) {
    return this.addForm.get(val)?.value;
  }

  close() {
    this.dialog.closeAll();
  }

}
