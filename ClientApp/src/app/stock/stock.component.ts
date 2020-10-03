import { Component, OnInit } from '@angular/core';

import { ProductService } from '../product.service';

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
  tableDataSrc = new MatTableDataSource();
  tableCols: string[] = ['idProduct', 'name', 'category', 'description', 'currentPrice', 'stock', 'purchases', 'update', 'delete'];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getStock();
    // }, error => console.error(error));
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

  delete(id: number): void {
    var index = this.findWithAttr(this.tableDataSrc.data, "id", id);
    this.tableDataSrc.data.splice(index, 1);
    this.productService.deleteProduct(id).subscribe();
  }

  onSearchInput(ev) {
    const searchTarget = ev.target.value;
    this.tableDataSrc.filter = searchTarget.trim().toLowerCase();
  }

}
