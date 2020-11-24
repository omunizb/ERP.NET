import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MessageService } from './messages/message.service';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private rolesUrl = 'api/roles';

  constructor(
    private messageService: MessageService,
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
}
