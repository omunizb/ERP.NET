import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Order } from '../models';
import { MessageService } from '../messages/message.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private ordersUrl = 'api/orders';
  private ordersDataSource = new BehaviorSubject<Observable<Order[]>>(null);

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

  getOrders(): Observable<Order[]> {
    this.ordersDataSource.next(this.http.get<Order[]>(this.baseUrl + this.ordersUrl).pipe(
      catchError(this.handleError<Order[]>('getOrders', []))));
    return this.ordersDataSource.value;
  }

  getOrder(id: string): Observable<Order> {
    const url = `${this.baseUrl + this.ordersUrl}/${id}`;
    return this.http.get<Order>(url).pipe(
      catchError(this.handleError<Order>(`getOrder id=${id}`)));
  }

  deleteOrder(order: Order): Observable<Order> {
    const url = `${this.baseUrl + this.ordersUrl}/${order.id}`;
    return this.http.delete<Order>(url, this.httpOptions).pipe(
      tap(_ => this.messageService.log(`Deleted order id=${order.id}.`)),
      catchError(this.handleError<Order>('deleteOrder'))
    );
  }

  updateOrder(order: Order): Observable<any> {
    const url = `${this.baseUrl + this.ordersUrl}/${order.id}`;
    return this.http.put(url, order, this.httpOptions).pipe(
      tap(_ => this.messageService.log(`Updated order id=${order.id}.`)),
      catchError(this.handleError<any>('updateOrder')));
  }
}
