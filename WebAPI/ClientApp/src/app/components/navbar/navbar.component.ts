import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { ColorSchemeService } from '@services';
import { RegisterComponent } from '../register/register.component';
import { LoginComponent } from '../login/login.component';
import { UserManagementSelector } from 'src/app/ngxs-store/user-management/user-management.selector';
import { Select, Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { UserManagementActions } from 'src/app/ngxs-store/user-management/user-management.action';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  @Select(UserManagementSelector.isAuthenticated) isAuthenticated$: Observable<boolean> | undefined;

  public themes = [
    {
        name: 'dark',
        icon: 'brightness_3'
    },
    {
        name: 'light',
        icon: 'wb_sunny'
    }
  ];

  constructor(
    private colorSchemeService: ColorSchemeService,
    private dialog: MatDialog,
    private store: Store) { }

  userLogin() {
    this.dialog.open(LoginComponent, {
      width: '30%',
      height: 'auto',
      panelClass: 'custom-dialog',
      autoFocus: false
    });
  }

  userRegister() {
    this.dialog.open(RegisterComponent, {
      width: '30%',
      height: 'auto',
      panelClass: 'custom-dialog',
      autoFocus: false
    });
  }

  updateTheme(theme: MatSelectChange) {
    this.colorSchemeService.update(theme.value);
  }

  logout() {
    this.store.dispatch(new UserManagementActions.Logout()).pipe().subscribe(res => {
      console.log(res);
      console.log('logged out');
    });
  }

}
