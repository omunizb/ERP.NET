import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { catchError, tap } from 'rxjs/operators';

import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  product;
  productForm;

  constructor(
    private productService: ProductService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.productForm = this.formBuilder.group({
      idProduct: [{ value: '', disabled: true }],
      name: ['', [Validators.required, Validators.maxLength(200)]],
      category: ['', Validators.maxLength(100)],
      description: ['', Validators.maxLength(2000)],
      currentPrice: ['', Validators.required],
      stock: [''],
      purchases: [{ value: '', disabled: true }]
    });

    this.getProduct();
  }

  onSubmit(productData) {
    console.log(productData);
    this.productService.updateProduct(productData).subscribe();
    this.goBack();
  }

  getProduct(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.productService.getProduct(id)
      .pipe(tap(product => this.productForm.patchValue(product)))
      .subscribe(product => this.product = product);
  }

  goBack(): void {
    this.location.back();
  }
}
