export class UserRequest {
    userName: string = '';
    password: string = '';
    firstName: string = '';
    lastName: string = '';
    email: string = '';
    role: RoleEnum = RoleEnum.USER;
}

export class User {
    id: string = '';
    userName: string = '';
    firstName: string = '';
    lastName: string = '';
    email: string = '';
    role: RoleEnum = RoleEnum.USER;
}

export class UserAuth {
    id: string = '';
    userName: string = '';
    firstName: string = '';
    lastName: string = '';
    email: string = '';
    token: string = '';
    // role:number=1;
    public constructor(init?: Partial<UserAuth>) {
        Object.assign(this, init);
    }
}

export enum RoleEnum {
    ADMIN,
    USER,
    AUTHOR
}