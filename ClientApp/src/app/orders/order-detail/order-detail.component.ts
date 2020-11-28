import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder, Validators } from '@angular/forms';
import { tap } from 'rxjs/operators';

import { OrderService } from '../order.service';
import { EmployeeService } from '../../employees/employee.service';
import { Employee } from '../../models';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements OnInit {
  orderForm;
  employees: Employee[] = [];
  priorities: number[] = [ 1, 2, 3 ];
  isAdmin: boolean;

  constructor(
    private orderService: OrderService,
    private employeeService: EmployeeService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.orderForm = this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      customerId: [{ value: '', disabled: true }],
      productId: [{ value: '', disabled: true }],
      employeeId: ['', Validators.required],
      time: [{ value: '', disabled: true }],
      quantity: [{ value: '', disabled: true }],
      price: [{ value: '', disabled: true }],
      priceVAT: [{ value: '', disabled: true }],
      state: [{ value: '', disabled: true }],
      priority: ['', Validators.required],
      expectedDelivery: [{ value: '', disabled: true }],
      delivered: [{ value: '', disabled: true }]
    });

    this.employeeService.getRole().subscribe(r => this.isAdmin = r);
    this.getEmployees();
    this.getOrder();
  }

  onSubmit(orderData) {
    this.orderService.updateOrder(orderData).subscribe();
    this.router.navigate(['/orders']);
  }

  getOrder(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.orderService.getOrder(id)
      .pipe(tap(order => this.orderForm.patchValue(order)))
      .subscribe();
  }

  getEmployees(): void {
    this.employeeService.getEmployees()
        .subscribe(employees => this.employees = employees as Employee[]);
    
    // Filter out former employees
    const activeEmployeeDate: Date = new Date('0001');
    this.employees.forEach(employee => {
      if (employee.departed !== activeEmployeeDate) {
        this.employees.splice(this.employees.indexOf(employee), 1);
      }
    });
  }

  goBack(): void {
    this.location.back();
  }
}
