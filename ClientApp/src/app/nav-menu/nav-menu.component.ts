import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { RoleService } from '../role.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;
  public role: string;

  constructor(
    private authorizeService: AuthorizeService,
    private roleService: RoleService
  ) { }

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.authorizeService.getUser().pipe(map(u => u && u.name)).subscribe(u => !!u ?
      this.roleService.getRole(u).subscribe(r => this.role = r) : this.role = null);
  }
}
