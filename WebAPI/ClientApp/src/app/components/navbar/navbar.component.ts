import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { ColorSchemeService } from '@services';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
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
    private dialog: MatDialog) { }

  userLogin() {

  }

  userRegister() {
    this.dialog.open(RegisterComponent, {
      width: '30%',
      height: 'auto',
      panelClass: 'custom-dialog'
    });
  }

  updateTheme(theme: MatSelectChange) {
    this.colorSchemeService.update(theme.value);
  }

}
