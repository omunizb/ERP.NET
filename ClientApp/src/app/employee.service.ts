import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Employee } from './models';

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

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    this.employeesData$ = this.http.get<Employee[]>(this.employeesUrl);
    return this.employeesData$;
  }

  getEmployee(id: number): Observable<Employee> {
    const url = `${this.employeesUrl}/${id}`;
    return this.http.get<Employee>(url);
  }

  deleteEmployee(employee: Employee): Observable<Employee> {
    const url = `${this.employeesUrl}/${employee.idEmployee}`;
    return this.http.delete<Employee>(url, this.httpOptions);
  }

  updateEmployee(employee: Employee): Observable<any> {
    const url = `${this.employeesUrl}/${employee.idEmployee}`;
    return this.http.put(url, employee, this.httpOptions);
  }

  addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.employeesUrl, employee, this.httpOptions);
  }
}
