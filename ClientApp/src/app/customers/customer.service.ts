import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Customer } from '../models';
import { MessageService } from '../messages/message.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customersUrl = 'api/customers';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

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

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl + this.customersUrl).pipe(
      catchError(this.handleError<Customer[]>('getCustomers', [])));
  }

  getCustomer(id: string): Observable<Customer> {
    const url = `${this.baseUrl + this.customersUrl}/${id}`;
    return this.http.get<Customer>(url).pipe(
      catchError(this.handleError<Customer>(`getCustomer id=${id}`)));
  }

  deleteCustomer(customer: Customer): Observable<Customer> {
    const url = `${this.baseUrl + this.customersUrl}/${customer.id}`;
    return this.http.delete<Customer>(url, this.httpOptions).pipe(
      tap(_ => this.messageService.log(`Deleted customer id=${customer.id}.`)),
      catchError(this.handleError<Customer>('deleteCustomer'))
    );
  }

  updateCustomer(customer: Customer): Observable<any> {
    const url = `${this.baseUrl + this.customersUrl}/${customer.id}`;
    return this.http.put(url, customer, this.httpOptions).pipe(
      tap(_ => this.messageService.log(`Updated customer id=${customer.id}.`)),
      catchError(this.handleError<any>('updateCustomer')));
  }
}
