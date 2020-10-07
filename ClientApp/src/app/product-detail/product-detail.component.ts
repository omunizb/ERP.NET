import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { tap } from 'rxjs/operators';

import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  productForm;

  constructor(
    private productService: ProductService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router
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

    if (this.route.snapshot.paramMap.get('id')) {
      this.getProduct();
    }
  }

  onSubmit(productData) {
    if (this.route.snapshot.paramMap.get('id')) {
      this.productService.updateProduct(productData).subscribe();
      this.router.navigate(['/stock']);
    }
    else {
      delete productData.idProduct;
      productData.purchases = 0;
      this.productService.addProduct(productData).subscribe();
      this.router.navigate(['/stock']);
    }
  }

  getProduct(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.productService.getProduct(id)
      .pipe(tap(product => this.productForm.patchValue(product)))
      .subscribe();
  }

  goBack(): void {
    this.location.back();
  }
}
