import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { RoleService } from './role.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private roleService: RoleService, private router: Router) {
  }
  canActivate(
    _next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.roleService.isAdmin().pipe(tap(isAdmin => this.handleAuthorization(isAdmin, state)))
  }

  private handleAuthorization(isAdmin: boolean | UrlTree, state: RouterStateSnapshot) {
    if (!isAdmin) {
      var urlArray = state.url.split('/');
      this.router.navigateByUrl(urlArray[urlArray.length - 2]);
    }
  }
}
