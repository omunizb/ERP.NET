import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { RoleService } from './role.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  role: string;

  constructor(
    private roleService: RoleService,
    private router: Router
  ) { }
  canActivate(
    _next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.roleService.provideRole().subscribe(r => this.role = r);
    return this.isAdmin().pipe(tap(isAdmin => this.handleAuthorization(isAdmin, state)))
  }

  private handleAuthorization(isAdmin: boolean | UrlTree, state: RouterStateSnapshot) {
    if (!isAdmin) {
      this.router.navigateByUrl(state.url.split('/')[1]);
    }
  }

  private isAdmin(): Observable<boolean> {
    if (this.role !== 'Admin') {
      return of(false);
    }
    return of(true);
  } 
}
