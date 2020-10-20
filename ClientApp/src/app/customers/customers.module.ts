import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { CustomersComponent } from './customers.component';
import { CustomersListComponent } from './customers-list/customers-list.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';

import { CustomersRoutingModule } from './customers-routing.module';

@NgModule({
  declarations: [
    CustomersComponent,
    CustomersListComponent,
    CustomerDetailComponent
  ],
  imports: [
    CustomersRoutingModule,
    SharedModule
  ]
})
export class CustomersModule { }
