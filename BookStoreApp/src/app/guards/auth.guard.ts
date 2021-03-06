import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { UserService } from "../services/user.service";

@Injectable({
    providedIn: 'root',
})
export class AuthGuard implements CanActivate {
    constructor(private _userService:UserService,
        private _router:Router){
    }
    canActivate(
        route: ActivatedRouteSnapshot, 
        state: RouterStateSnapshot): 
        boolean |
        UrlTree |
        Observable<boolean | 
        UrlTree> | 
        Promise<boolean | UrlTree> {

        if(!this._userService.loggedIn()){
            alert("You are not authentificated!")
            this._router.navigateByUrl('user/login');
            return false;
        }

        return true;
    }
}