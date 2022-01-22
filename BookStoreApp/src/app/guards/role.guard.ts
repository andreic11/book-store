import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { UserService } from "../services/user.service";

@Injectable({
    providedIn: 'root',
})
export class RoleGuard implements CanActivate {
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

        let role = this._userService.getRole();
        if(role.toUpperCase().localeCompare("ADMIN")==0){
            return true;
        }
        alert("You don't have admin rights");
        this._router.navigateByUrl('home');
        return false;
    }
}