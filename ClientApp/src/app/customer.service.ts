import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Customer } from './models';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customersUrl = 'api/customers';
  private customersDataSource = new BehaviorSubject<any>('');
  customersData$ = this.customersDataSource.asObservable();

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<Customer[]> {
    this.customersData$ = this.http.get<Customer[]>(this.customersUrl);
    return this.customersData$;
  }

  getCustomer(id: number): Observable<Customer> {
    const url = `${this.customersUrl}/${id}`;
    return this.http.get<Customer>(url);
  }

  deleteCustomer(customer: Customer): Observable<Customer> {
    const url = `${this.customersUrl}/${customer.id}`;
    return this.http.delete<Customer>(url, this.httpOptions);
  }

  updateCustomer(customer: Customer): Observable<any> {
    const url = `${this.customersUrl}/${customer.id}`;
    return this.http.put(url, customer, this.httpOptions);
  }
}
