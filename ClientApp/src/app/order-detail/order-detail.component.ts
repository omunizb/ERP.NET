import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder, Validators } from '@angular/forms';
import { tap } from 'rxjs/operators';

import { OrderService } from '../order.service';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements OnInit {
  orderForm;
  employees;

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
      idOrder: [{ value: '', disabled: true }],
      idCustomer: [{ value: '', disabled: true }],
      idProduct: [{ value: '', disabled: true }],
      idEmployee: ['', Validators.required],
      time: [{ value: '', disabled: true }],
      quantity: [{ value: '', disabled: true }],
      price: [{ value: '', disabled: true }],
      priceVAT: [{ value: '', disabled: true }],
      state: [{ value: '', disabled: true }],
      priority: ['', Validators.required],
      expectedDelivery: [{ value: '', disabled: true }],
      delivered: [{ value: '', disabled: true }]
    });

    this.getEmployees();
    this.getOrder();
  }

  onSubmit(orderData) {
    this.orderService.updateOrder(orderData).subscribe();
    this.orderService.getOrders().subscribe();
    this.router.navigate(['/orders']);
  }

  getOrder(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.orderService.getOrder(id)
      .pipe(tap(order => this.orderForm.patchValue(order)))
      .subscribe();
  }

  getEmployees(): void {
    this.employeeService.getEmployees()
        .subscribe(employees => this.employees = employees);
    console.log(this.employees)
  }

  goBack(): void {
    this.location.back();
  }
}
