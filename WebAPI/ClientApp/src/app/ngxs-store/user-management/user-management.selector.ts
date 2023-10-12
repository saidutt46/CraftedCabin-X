import { Selector } from "@ngxs/store";
import { UserManagementState } from "./user-management.state";
import { UserManagementStateModel } from "./user-management.model";

export class UserManagementSelector {
  @Selector([UserManagementState])
  static getUserProfile(state: UserManagementStateModel) {
    return state.userProfile;
  }


  @Selector([UserManagementState])
  static isAuthenticated(state: UserManagementStateModel) {
    return state.isAuthenticated;
  }

  @Selector([UserManagementState])
  static formLoading(state: UserManagementStateModel) {
    return state.formLoading;
  }

}