import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Order } from '../models';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private ordersUrl = 'api/orders';
  private ordersDataSource = new BehaviorSubject<any>('');
  ordersData$ = this.ordersDataSource.asObservable();

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getOrders(): Observable<Order[]> {
    this.ordersData$ = this.http.get<Order[]>(this.baseUrl + this.ordersUrl);
    return this.ordersData$;
  }

  getOrder(id: number): Observable<Order> {
    const url = `${this.baseUrl + this.ordersUrl}/${id}`;
    return this.http.get<Order>(url);
  }

  deleteOrder(order: Order): Observable<Order> {
    const url = `${this.baseUrl + this.ordersUrl}/${order.id}`;
    return this.http.delete<Order>(url, this.httpOptions);
  }

  updateOrder(order: Order): Observable<any> {
    const url = `${this.baseUrl + this.ordersUrl}/${order.id}`;
    return this.http.put(url, order, this.httpOptions);
  }
}
