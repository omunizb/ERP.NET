import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder } from '@angular/forms';

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
      name: '',
      category: '',
      description: '',
      currentPrice: '',
      stock: '',
      purchases: ''
    });
    this.getProduct();
  }

  onSubmit(productData) {
    this.productForm.reset();

    console.warn('Your order has been submitted', productData);
  }

  getProduct(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.productService.getProduct(id)
      .subscribe(product => this.product = product);
  }

  goBack(): void {
    this.location.back();
  }
}
