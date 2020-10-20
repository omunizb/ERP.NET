import { Injectable } from '@angular/core';
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

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Order[]> {
    this.ordersData$ = this.http.get<Order[]>(this.ordersUrl);
    return this.ordersData$;
  }

  getStats(date: Date): Observable<number[]> {
    const month = date.getMonth() + 1;
    const year = date.getFullYear();
    const url = `${this.ordersUrl}/${year}/${month}`;
    return this.http.get<number[]>(url);
  }

  getOrder(id: number): Observable<Order> {
    const url = `${this.ordersUrl}/${id}`;
    return this.http.get<Order>(url);
  }

  deleteOrder(order: Order): Observable<Order> {
    const url = `${this.ordersUrl}/${order.id}`;
    return this.http.delete<Order>(url, this.httpOptions);
  }

  updateOrder(order: Order): Observable<any> {
    const url = `${this.ordersUrl}/${order.id}`;
    return this.http.put(url, order, this.httpOptions);
  }
}
