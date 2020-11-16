import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Stat } from '../models';

@Injectable({
  providedIn: 'root'
})
export class StatsService {
  private ordersUrl = 'api/orders';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getStats(date: Date): Observable<number[]> {
    const month = date.getMonth() + 1;
    const year = date.getFullYear();
    const url = `${this.baseUrl + this.ordersUrl}/${year}/${month}`;
    return this.http.get<number[]>(url);
  }

  getMonthlySales(): Observable<Stat[]> {
    const url = `${this.baseUrl + this.ordersUrl}/getmonthlysales`;
    return this.http.get<Stat[]>(url);
  }
}
