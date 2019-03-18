export interface IUser {
    Username: string;
}
export class UserLogin implements IUser {
    Username: string;
    Password: string;
}

export class UserToken implements IUser {
    Username: string;
    Token: string;
}
