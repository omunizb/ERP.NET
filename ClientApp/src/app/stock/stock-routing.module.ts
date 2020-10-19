import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StockComponent } from './stock.component';
import { StockListComponent } from './stock-list/stock-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';

const routes: Routes = [
  { path: '',
    component: StockComponent,
    children: [
      { path: '', component: StockListComponent },
      { path: 'detail', component: ProductDetailComponent },
      { path: 'detail/:id', component: ProductDetailComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockRoutingModule { }
