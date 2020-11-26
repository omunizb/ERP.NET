import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { RoleService } from '../role.service';
import { Observable } from 'rxjs';

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
    this.roleService.provideRole().subscribe(r => this.role = r);
  }
}
