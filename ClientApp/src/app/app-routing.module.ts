import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockComponent } from './stock/stock.component'
import { CostumersComponent } from './costumers/costumers.component'
import { EmployeesComponent } from './employees/employees.component'
import { OrdersComponent } from './orders/orders.component'
import { StatsComponent } from './stats/stats.component'
import { LoginComponent } from './login/login.component'

const routes: Routes = [
  { path: 'stock', component: StockComponent },
  { path: 'customers', component: CostumersComponent },
  { path: 'employees', component: EmployeesComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'stats', component: StatsComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: 'stock' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
