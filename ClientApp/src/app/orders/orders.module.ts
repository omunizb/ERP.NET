import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { OrdersComponent } from './orders.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrderDetailComponent } from './order-detail/order-detail.component';

import { OrdersRoutingModule } from './orders-routing.module';

@NgModule({
  declarations: [
    OrdersComponent,
    OrdersListComponent,
    OrderDetailComponent
  ],
  imports: [
    OrdersRoutingModule,
    SharedModule
  ]
})
export class OrdersModule { }
