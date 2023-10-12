import { UserProfileModel } from "@models";

export class UserManagementStateModel {
    userProfile: UserProfileModel | null = null;
    isAuthenticated?: boolean;
    token: string | null = null;
    expiration: Date | null = null;
    isAdmin!: boolean;
    formLoading!: boolean;
}