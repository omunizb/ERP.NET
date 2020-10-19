import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { OrdersComponent } from './orders/orders.component';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { StatsComponent } from './stats/stats.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'stock', loadChildren: () => import('./stock/stock.module').then(m => m.StockModule) },
  { path: 'customers', loadChildren: () => import('./customers/customers.module').then(m => m.CustomersModule) },
  { path: 'employees', component: EmployeesComponent },
  { path: 'employee-detail', component: EmployeeDetailComponent },
  { path: 'employee-detail/:id', component: EmployeeDetailComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'order-detail/:id', component: OrderDetailComponent },
  { path: 'stats', component: StatsComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: 'stock', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
