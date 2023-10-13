import { Action, State, StateContext, Store } from "@ngxs/store";
import { UserManagementStateModel } from "./user-management.model";
import { Inject, Injectable } from "@angular/core";
import { NOTIFICATION_SERV_TOKEN, NotificationService, UserAuthenticationService } from "@services";
import { catchError, throwError, tap } from "rxjs";
import { UserManagementActions } from "./user-management.action";
import jwt_decode from "jwt-decode";

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
                formLoading: false,
                isAdmin: this.userRoles.includes('Admin')
              });
              this.notifier.successNotification(`Welcome to the Cabin!,  ${res.userProfile.userName.toUpperCase()}`);
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
        return this.authService.registerAdmin(payload).pipe(
          catchError((x) => {
            return throwError(x);
          }),
          tap((res) => {
              patchState({
                formLoading: false
              });
              this.notifier.successNotification(`Welcome, Weave Yourself into Our Community!`);
          }, err => {
            patchState({
              formLoading: false
            });
            this.notifier.errorNotification(`Error: ${err.error.message}`);
          })
        );
      }

      @Action([UserManagementActions.Logout])
      logout({patchState}: StateContext<UserManagementStateModel>) {
        patchState({
            userProfile: null,
            isAuthenticated: false,
            token: null,
            isAdmin: false,
            expiration: null
        });
        this.notifier.successNotification(`logged out`);
        return;
      }

      get userRoles(): string[] {
        const token = localStorage.getItem('token');  // Assume the token is stored in localStorage
        if (!token) return [];
        const decodedToken: any = jwt_decode(token);
        return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || [];
      }

  }
