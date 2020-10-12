import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Product } from './models';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private stockUrl = 'api/products';
  private stockDataSource = new BehaviorSubject<any>('');
  stockData$ = this.stockDataSource.asObservable();

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getStock(): Observable<Product[]> {
    this.stockData$ = this.http.get<Product[]>(this.stockUrl);
    return this.stockData$;
  }

  getProduct(id: number): Observable<Product> {
    const url = `${this.stockUrl}/${id}`;
    return this.http.get<Product>(url);
  }

  deleteProduct(product: Product): Observable<Product> {
    const url = `${this.stockUrl}/${product.id}`;
    return this.http.delete<Product>(url, this.httpOptions);
  }

  updateProduct(product: Product): Observable<any> {
    const url = `${this.stockUrl}/${product.id}`;
    return this.http.put(url, product, this.httpOptions);
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.stockUrl, product, this.httpOptions);
  }
}
