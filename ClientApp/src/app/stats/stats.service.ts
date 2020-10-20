import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatsService {
  private ordersUrl = 'api/orders';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getStats(date: Date): Observable<number[]> {
    const month = date.getMonth() + 1;
    const year = date.getFullYear();
    const url = `${this.ordersUrl}/${year}/${month}`;
    return this.http.get<number[]>(url);
  }
}
