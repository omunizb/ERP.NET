import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { StockComponent } from './stock.component';
import { StockListComponent } from './stock-list/stock-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';

import { StockRoutingModule } from './stock-routing.module';

@NgModule({
  declarations: [
    StockComponent,
    StockListComponent,
    ProductDetailComponent
  ],
  imports: [
    StockRoutingModule,
    SharedModule
  ]
})
export class StockModule { }
