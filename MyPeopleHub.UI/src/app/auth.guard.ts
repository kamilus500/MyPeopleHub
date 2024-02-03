import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountDataService } from './services/data-services/account-data.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    
    isLogin: boolean = false;

    constructor(private accountDataService: AccountDataService, private router: Router) {
        this.accountDataService.loginStatus$.subscribe(s => {
            this.isLogin = s;
        })
    }

    canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.isLogin) {
        return true;
    } else {
        return this.router.createUrlTree(['/login']);
    }
    }
}
