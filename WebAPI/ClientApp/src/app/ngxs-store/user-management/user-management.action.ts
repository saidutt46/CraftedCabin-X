import { UserLoginModel, UserRegisterModel } from "@models";

export namespace UserManagementActions {
    export class Login {
        static readonly type = '[UserManagement] Login';
        constructor(public payload: UserLoginModel) { }
    }

    export class Register {
        static readonly type = '[UserManagement] Register';
        constructor(public payload: UserRegisterModel) { }
    }
 }