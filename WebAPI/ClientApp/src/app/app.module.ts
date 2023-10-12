import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { AppRoutingModule, MaterialModule } from '@modules';
import { ConsoleLoggingService, LOGGING_SERV_TOKEN, NOTIFICATION_SERV_TOKEN, NotificationService } from '@services';
import { HomeComponent, LoginComponent, NavbarComponent, RegisterComponent } from '@components';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { NgxsModule } from '@ngxs/store';
import { UserManagementState } from './ngxs-store/user-management/user-management.state';
import { NgxsStoragePluginModule } from '@ngxs/storage-plugin';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    FlexLayoutModule,
    MaterialModule,
    NgxsModule.forRoot([
      UserManagementState
    ]),
    NgxsFormPluginModule.forRoot(),
    NgxsReduxDevtoolsPluginModule.forRoot(),
    NgxsStoragePluginModule.forRoot({key: 'userauth'})
  ],
  providers: [
    { provide: NOTIFICATION_SERV_TOKEN, useClass: NotificationService },
    { provide: LOGGING_SERV_TOKEN, useClass: ConsoleLoggingService },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

