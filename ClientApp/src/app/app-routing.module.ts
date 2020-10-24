import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { LoginComponent } from './login/login.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { HomeComponent } from './home/home.component'

const routes: Routes = [
  { path: '', component: HomeComponent , pathMatch: 'full' },
  { path: 'stock', loadChildren: () => import('./stock/stock.module').then(m => m.StockModule), canActivate: [AuthorizeGuard] },
  { path: 'customers', loadChildren: () => import('./customers/customers.module').then(m => m.CustomersModule), canActivate: [AuthorizeGuard] },
  { path: 'employees', loadChildren: () => import('./employees/employees.module').then(m => m.EmployeesModule), canActivate: [AuthorizeGuard] },
  { path: 'orders', loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule), canActivate: [AuthorizeGuard] },
  { path: 'stats', loadChildren: () => import('./stats/stats.module').then(m => m.StatsModule), canActivate: [AuthorizeGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
