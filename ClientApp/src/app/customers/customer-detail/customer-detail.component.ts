import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder, Validators } from '@angular/forms';
import { tap } from 'rxjs/operators';

import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
  customerForm;

  constructor(
    private customerService: CustomerService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.customerForm = this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: ['', [Validators.required, Validators.maxLength(35)]],
      surname: ['', [Validators.required, Validators.maxLength(35)]],
      email: ['', [Validators.required, Validators.maxLength(320)]],
      firstPurchase: [{ value: '', disabled: true }],
      latestPurchase: [{ value: '', disabled: true }],
      totalExpenditure: [{ value: '', disabled: true }],
      totalPurchases: [{ value: '', disabled: true }],
      deliveryAddress: ['', [Validators.required, Validators.maxLength(320)]],
      billingAddress: ['', [Validators.required, Validators.maxLength(320)]],
      bankAccount: ['', [Validators.required, Validators.maxLength(50)]]
    });

    this.getCustomer();
  }

  onSubmit(customerData) {
    this.customerService.updateCustomer(customerData).subscribe();
    this.customerService.getCustomers().subscribe();
    this.router.navigate(['/customers']);
  }

  getCustomer(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.customerService.getCustomer(id)
      .pipe(tap(customer => this.customerForm.patchValue(customer)))
      .subscribe();
  }

  goBack(): void {
    this.location.back();
  }
}
