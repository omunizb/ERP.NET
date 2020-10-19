import { Component, OnInit } from '@angular/core';

import { ProductService } from './product.service';

import { ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  template: `
    <h2>Stock</h2>
    <router-outlet></router-outlet>
  `,
  styles: [`
    h2 {
      padding: 15px;
    {
  `],
})
export class StockComponent implements OnInit {
  title = 'Stock';
  tableDataSrc = new MatTableDataSource();
  tableCols: string[] = ['id', 'name', 'category', 'description', 'currentPrice', 'stock', 'purchases', 'update', 'delete'];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getStock();
    this.tableDataSrc.sort = this.sort;
    this.tableDataSrc.paginator = this.paginator;
  }

  getStock(): void {
    this.productService.getStock()
        .subscribe(stock => this.tableDataSrc.data = stock);
  }

  delete(product): void {
    this.tableDataSrc.data = this.tableDataSrc.data.filter(p => p !== product);
    this.productService.deleteProduct(product).subscribe();
  }

  onSearchInput(ev) {
    const searchTarget = ev.target.value;
    this.tableDataSrc.filter = searchTarget.trim().toLowerCase();
  }
}
