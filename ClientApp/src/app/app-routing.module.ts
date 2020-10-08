import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockComponent } from './stock/stock.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { OrdersComponent } from './orders/orders.component';
import { StatsComponent } from './stats/stats.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'stock', component: StockComponent },
  { path: 'product', component: ProductDetailComponent },
  { path: 'product/:id', component: ProductDetailComponent },
  { path: 'customers', component: CustomersComponent },
  { path: 'customer-detail/:id', component: CustomerDetailComponent },
  { path: 'employees', component: EmployeesComponent },
  { path: 'employee-detail', component: EmployeeDetailComponent },
  { path: 'employee-detail/:id', component: EmployeeDetailComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'stats', component: StatsComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: 'stock', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
