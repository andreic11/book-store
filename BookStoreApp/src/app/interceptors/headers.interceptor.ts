import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserService } from '../services/user.service';


@Injectable()
export class HeadersInterceptor implements HttpInterceptor {

    constructor(private userService: UserService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        if (this.userService.loggedIn()) {
            let jwtToken = localStorage.getItem(UserService.AUTH_KEY);
            jwtToken = jwtToken ? jwtToken : "";

            req = req.clone({
                setHeaders: {
                    'Authorization': `${jwtToken}`,
                },
            });
        }

        return next.handle(req);
    }

}
