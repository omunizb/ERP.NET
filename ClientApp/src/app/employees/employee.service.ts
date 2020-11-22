import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Employee } from '../models';
import { MessageService } from '../messages/message.service';
import { RolesService } from '../roles.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeesUrl = 'api/employees';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private messageService: MessageService,
    private rolesService: RolesService,
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

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + this.employeesUrl).pipe(
        catchError(this.handleError<Employee[]>('getEmployees', [])));
  }

  getEmployee(id: string): Observable<Employee> {
    const url = `${this.baseUrl + this.employeesUrl}/${id}`;
    return this.http.get<Employee>(url).pipe(
      catchError(this.handleError<Employee>(`getEmployee id=${id}`)));
  }

  deleteEmployee(employee: Employee): Observable<Employee> {
    const url = `${this.baseUrl + this.employeesUrl}/${employee.id}`;
    return this.http.delete<Employee>(url, this.httpOptions).pipe(
      tap(_ => this.messageService.log(`Deleted employee id=${employee.id}.`)),
      catchError(this.handleError<Employee>('deleteEmployee'))
    );
  }

  updateEmployee(employee: Employee): Observable<any> {
    const url = `${this.baseUrl + this.employeesUrl}/${employee.id}`;
    return this.http.put(url, employee, this.httpOptions).pipe(
      tap(_ => this.messageService.log(`Updated employee id=${employee.id}.`)),
      catchError(this.handleError<any>('updateEmployee')));
  }

  addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.baseUrl + this.employeesUrl, employee, this.httpOptions).pipe(
      tap((newEmployee: Employee) => this.messageService.log(`Added employee with id=${newEmployee.id}.`)),
      catchError(this.handleError<Employee>('addEmployee')));
  }
}
