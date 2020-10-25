import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Employee } from '../models';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeesUrl = 'api/employees';
  private employeesDataSource = new BehaviorSubject<any>('');
  employeesData$ = this.employeesDataSource.asObservable();

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getEmployees(): Observable<Employee[]> {
    this.employeesData$ = this.http.get<Employee[]>(this.baseUrl + this.employeesUrl);
    return this.employeesData$;
  }

  getEmployee(id: number): Observable<Employee> {
    const url = `${this.baseUrl + this.employeesUrl}/${id}`;
    return this.http.get<Employee>(url);
  }

  deleteEmployee(employee: Employee): Observable<Employee> {
    const url = `${this.baseUrl + this.employeesUrl}/${employee.id}`;
    return this.http.delete<Employee>(url, this.httpOptions);
  }

  updateEmployee(employee: Employee): Observable<any> {
    const url = `${this.baseUrl + this.employeesUrl}/${employee.id}`;
    return this.http.put(url, employee, this.httpOptions);
  }

  addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.baseUrl + this.employeesUrl, employee, this.httpOptions);
  }
}
