import { UserProfileModel } from "@models";

export class UserLoginModel {
    userName!: string;
    password!: string;
}

export class LoginResponseModel {
    token!: string;
    expiration!: Date;
    userProfile!: UserProfileModel;
  }