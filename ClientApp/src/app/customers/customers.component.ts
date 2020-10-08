import { Component, OnInit } from '@angular/core';

import { CustomerService } from '../customer.service';

import { ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  title = 'Stock';
  tableDataSrc = new MatTableDataSource();
  tableCols: string[] = [
    'idCustomer', 
    'name', 
    'surname', 
    'email', 
    'firstPurchase', 
    'latestPurchase', 
    'totalExpenditure', 
    'totalPurchases', 
    'deliveryAddress', 
    'billingAddress', 
    'bankAccount',
    'update',
    'delete'
  ];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.getCustomers();
    this.tableDataSrc.sort = this.sort;
    this.tableDataSrc.paginator = this.paginator;
  }

  getCustomers(): void {
    this.customerService.getCustomers()
        .subscribe(customers => this.tableDataSrc.data = customers);
  }

  delete(id: number): void {
    this.customerService.deleteCustomer(id).subscribe();
    this.getCustomers();
  }

  onSearchInput(ev) {
    const searchTarget = ev.target.value;
    this.tableDataSrc.filter = searchTarget.trim().toLowerCase();
  }

}
