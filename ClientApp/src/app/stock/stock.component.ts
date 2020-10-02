import { Component, OnInit } from '@angular/core';

import { Product } from '../product';
import { ProductService } from '../product.service';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {
  title = 'Stock';
  baseUrl = 'https://localhost:44362/api/products';
  tableDataSrc = new MatTableDataSource();
  tableCols: string[] = ['idProduct', 'name', 'category', 'description', 'currentPrice', 'stock', 'purchases', 'update', 'delete'];
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private productService: ProductService, private http: HttpClient) { }

  ngOnInit() {
    // this.getStock();
    this.http.get<Product[]>(this.baseUrl).subscribe(data => {  
      this.tableDataSrc.data = data;
      console.log(data);  
    }, error => console.error(error));
    this.tableDataSrc.sort = this.sort;
    this.tableDataSrc.paginator = this.paginator;
  }

  getStock(): void {
    this.productService.getStock()
        .subscribe(stock => this.tableDataSrc.data = stock);
  }

  // https://stackoverflow.com/a/7178381
  findWithAttr(array, attr, value) {
    for(var i = 0; i < array.length; i += 1) {
        if(array[i][attr] === value) {
            return i;
        }
    }
    return -1;
  }

  delete(product: number) {
    const id = product;
    const url = `${this.baseUrl}/${id}`;
    
    var index = this.findWithAttr(this.tableDataSrc.data, "id", id);

    this.tableDataSrc.data.splice(index, 1);

    this.http.delete<Product>(url, this.httpOptions).subscribe();
  }

  onSearchInput(ev) {
    const searchTarget = ev.target.value;
    this.tableDataSrc.filter = searchTarget.trim().toLowerCase();
  }

}
