import { Action, State, StateContext, Store } from "@ngxs/store";
import { UserManagementStateModel } from "./user-management.model";
import { Inject, Injectable } from "@angular/core";
import { NOTIFICATION_SERV_TOKEN, NotificationService, UserAuthenticationService } from "@services";
import { catchError, throwError, tap } from "rxjs";
import { UserManagementActions } from "./user-management.action";

@State<UserManagementStateModel>({
    name: 'userauth',
    defaults: {
        userProfile: null,
        isAuthenticated: false,
        token: null,
        expiration: null,
        isAdmin: false,
        formLoading: false
    }
  })

  @Injectable()
  export class UserManagementState {
    constructor(
        @Inject(NOTIFICATION_SERV_TOKEN) private notifier: NotificationService,
        private authService: UserAuthenticationService,
        private store: Store
      ) {}

      @Action(UserManagementActions.Login)
      loginUser({patchState}: StateContext<UserManagementStateModel>, {payload}: any) {
        patchState({
          formLoading: true
        });
        return this.authService.login(payload).pipe(
          catchError((x) => {
            return throwError(x);
          }),
          tap((res) => {
              localStorage.setItem('token', res.token);
              localStorage.setItem('currentUser', res.userProfile.id);
              const token = localStorage.getItem('token');
              patchState({
                userProfile: res.userProfile,
                isAuthenticated: token ? true : false,
                formLoading: false
              });
              this.notifier.successNotification(`${res.userProfile.userName.toUpperCase()}: successfully logged In`);
          }, err => {
            patchState({
              formLoading: false
            });
            this.notifier.errorNotification(`Error: ${err.error}`);
          })
        );
      }
    
      @Action(UserManagementActions.Register)
      registerUser({patchState}: StateContext<UserManagementStateModel>, {payload}: any) {
        patchState({
          formLoading: true
        });
        return this.authService.registerUser(payload).pipe(
          catchError((x) => {
            return throwError(x);
          }),
          tap((res) => {
              patchState({
                formLoading: false
              });
              this.notifier.successNotification(`${res.message}`);
          }, err => {
            patchState({
              formLoading: false
            });
            this.notifier.errorNotification(`Error: ${err.error.message}`);
          })
        );
      }
  }

