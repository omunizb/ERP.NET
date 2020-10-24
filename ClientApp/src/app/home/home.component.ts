import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;

  constructor(private authorizeService: AuthorizeService) { }

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
  }
}
