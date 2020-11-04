import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Product } from '../models';
import { MessageService } from '../messages/message.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private stockUrl = 'api/products';
  private stockDataSource = new BehaviorSubject<Observable<Product[]>>(null);

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

  getStock(): Observable<Product[]> {
    this.stockDataSource.next(this.http.get<Product[]>(this.baseUrl + this.stockUrl).pipe(
      catchError(this.handleError<Product[]>('getStock', []))));
    return this.stockDataSource.value;
  }

  getProduct(id: number): Observable<Product> {
    const url = `${this.baseUrl + this.stockUrl}/${id}`;
    return this.http.get<Product>(url).pipe(
      catchError(this.handleError<Product>(`getProduct id=${id}`)));
  }

  deleteProduct(product: Product): Observable<Product> {
    const url = `${this.baseUrl + this.stockUrl}/${product.id}.`;
    return this.http.delete<Product>(url, this.httpOptions).pipe(
      tap(_ => this.messageService.log(`Deleted product id=${product.id}.`)),
      catchError(this.handleError<Product>('deleteProduct'))
    );
  }

  updateProduct(product: Product): Observable<any> {
    const url = `${this.baseUrl + this.stockUrl}/${product.id}`;
    return this.http.put(url, product, this.httpOptions).pipe(
      tap(_ => this.messageService.log(`Updated product id=${product.id}.`)),
      catchError(this.handleError<any>('updateProduct')));
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.baseUrl + this.stockUrl, product, this.httpOptions).pipe(
      tap((newProduct: Product) => this.messageService.log(`Added product with id=${newProduct.id}.`)),
      catchError(this.handleError<Product>('addProduct')));
  }
}
