import { Component, OnInit } from '@angular/core';

import { EmployeeService } from '../employee.service';

import { ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
  title = 'Employees';
  tableDataSrc = new MatTableDataSource();
  tableCols: string[] = [
    'id', 
    'name', 
    'surname', 
    'hired', 
    'departed', 
    'salary', 
    'position',
    'update',
    'delete'
  ];
  
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.getEmployees();
    this.tableDataSrc.sort = this.sort;
    this.tableDataSrc.paginator = this.paginator;
  }

  getEmployees(): void {
    this.employeeService.getEmployees()
        .subscribe(employees => this.tableDataSrc.data = employees);
  }

  delete(employee): void {
    this.tableDataSrc.data = this.tableDataSrc.data.filter(e => e !== employee);
    this.employeeService.deleteEmployee(employee).subscribe();
  }

  onSearchInput(ev) {
    const searchTarget = ev.target.value;
    this.tableDataSrc.filter = searchTarget.trim().toLowerCase();
  }
}
