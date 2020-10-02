import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from './product';
import { STOCK } from './mock-stock'; 

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }

  getStock(): Observable<Product[]> {
    return of(STOCK);
  }
}
