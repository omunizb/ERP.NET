import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { MessageService } from './messages/message.service';
import { AuthorizeService } from '../api-authorization/authorize.service';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private rolesUrl = 'api/roles';
  public role: BehaviorSubject<string | null> = new BehaviorSubject(null);
  public id: BehaviorSubject<string | null> = new BehaviorSubject(null);

  constructor(
    private messageService: MessageService,
    private authorize: AuthorizeService,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.messageService.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  getRole(username: string): Observable<string> {
    const url = `${this.baseUrl + this.rolesUrl}/${username}`;
    return this.http.get(url, {responseType: 'text'}).pipe(
      catchError(this.handleError<string>(`getRole username=${username}`)));
  }

  provideRole(): Observable<string> {
    this.authorize.getUser().pipe(map(u => u && u.name)).subscribe(u => !!u ?
      this.getRole(u).subscribe(r => this.role.next(r)) : this.role = null);
    return this.role.asObservable();
  }

  isAdmin(): Observable<boolean> {
    return this.provideRole().pipe(map(r => r === 'Admin'));
  }

  getId(username: string): Observable<string> {
    const url = `${this.baseUrl + this.rolesUrl}/${username}/getid`;
    return this.http.get(url, {responseType: 'text'}).pipe(
      catchError(this.handleError<string>(`getRole username=${username}`)));
  }

  provideId(): Observable<string> {
    this.authorize.getUser().pipe(map(u => u && u.name)).subscribe(u => !!u ?
      this.getId(u).subscribe(i => this.id.next(i)) : this.id = null);
    return this.id.asObservable();
  }
}
