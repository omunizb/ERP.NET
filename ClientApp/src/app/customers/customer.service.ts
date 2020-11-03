import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Customer } from '../models';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customersUrl = 'api/customers';
  private customersDataSource = new BehaviorSubject<Observable<Customer[]>>(null);

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getCustomers(): Observable<Customer[]> {
    this.customersDataSource.next(this.http.get<Customer[]>(this.baseUrl + this.customersUrl));
    return this.customersDataSource.value;
  }

  getCustomer(id: number): Observable<Customer> {
    const url = `${this.baseUrl + this.customersUrl}/${id}`;
    return this.http.get<Customer>(url);
  }

  deleteCustomer(customer: Customer): Observable<Customer> {
    const url = `${this.baseUrl + this.customersUrl}/${customer.id}`;
    return this.http.delete<Customer>(url, this.httpOptions);
  }

  updateCustomer(customer: Customer): Observable<any> {
    const url = `${this.baseUrl + this.customersUrl}/${customer.id}`;
    return this.http.put(url, customer, this.httpOptions);
  }
}
