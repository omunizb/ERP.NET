import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private stockUrl = 'https://localhost:44362/api/products';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getStock(): Observable<Product[]> {
    return this.http.get<Product[]>(this.stockUrl);
  }

  getProduct(id: number): Observable<Product> {
    const url = `${this.stockUrl}/${id}`;
    return this.http.get<Product>(url);
  }

  deleteProduct(id: number): Observable<Product> {
    const url = `${this.stockUrl}/${id}`;
    return this.http.delete<Product>(url, this.httpOptions);
  }

  updateProduct(product: Product): Observable<any> {
    const employeeUrl = `${this.stockUrl}/${product.idProduct}`;
    return this.http.put(employeeUrl, product, this.httpOptions);
  }
}
