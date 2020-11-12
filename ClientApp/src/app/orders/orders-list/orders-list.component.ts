import { Component, OnInit } from '@angular/core';

import { OrderService } from '../order.service';

import { ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {
  title = 'Orders';
  tableDataSrc = new MatTableDataSource();
  tableCols: string[] = [
    'id', 
    'customerId', 
    'productId', 
    'employeeId', 
    'time',  
    'quantity', 
    'price', 
    'priceVAT', 
    'state', 
    'priority',
    'expectedDelivery',
    'delivered',
    'update',
    'delete'
  ];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.getOrders();
    this.tableDataSrc.sort = this.sort;
    this.tableDataSrc.paginator = this.paginator;
  }

  getOrders(): void {
    this.orderService.getOrders()
        .subscribe(orders => this.tableDataSrc.data = orders);
  }

  delete(order): void {
    this.tableDataSrc.data = this.tableDataSrc.data.filter(o => o !== order);
    this.orderService.deleteOrder(order).subscribe();
  }

  onSearchInput(ev) {
    const searchTarget = ev.target.value;
    this.tableDataSrc.filter = searchTarget.trim().toLowerCase();
  }
}
