import { Component } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { ColorSchemeService } from '@services';

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

  constructor(private colorSchemeService: ColorSchemeService) { }

  userLogin() {

  }

  userRegister() {
  }

  updateTheme(theme: MatSelectChange) {
    this.colorSchemeService.update(theme.value);
  }

}
