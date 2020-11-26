import { Component, OnInit } from '@angular/core';

import { CustomerService } from '../customer.service';

import { ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.css']
})
export class CustomersListComponent implements OnInit {
  title = 'Customers';
  isAdmin: boolean;
  tableDataSrc = new MatTableDataSource();
  tableCols: string[] = [
    'id', 
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
    this.customerService.getRole().subscribe(r => this.isAdmin = r);
  }

  getCustomers(): void {
    this.customerService.getCustomers()
        .subscribe(customers => this.tableDataSrc.data = customers);
  }

  delete(customer): void {
    this.tableDataSrc.data = this.tableDataSrc.data.filter(c => c !== customer);
    this.customerService.deleteCustomer(customer).subscribe();
  }

  onSearchInput(ev) {
    const searchTarget = ev.target.value;
    this.tableDataSrc.filter = searchTarget.trim().toLowerCase();
  }

  getTableCols(): string[] {
    return (this.isAdmin ? this.tableCols : this.tableCols.filter(e => e !== 'totalExpenditure' && e !== 'totalPurchases'));
  }
}
