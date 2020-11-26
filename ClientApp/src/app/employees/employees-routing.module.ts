import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminGuard } from '../admin.guard';
import { EmployeesComponent } from './employees.component';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';



const routes: Routes = [
  { path: '',
    component: EmployeesComponent,
    children: [
      { path: '', component: EmployeesListComponent },
      { path: 'detail', component: EmployeeDetailComponent, canActivate: [AdminGuard] },
      { path: 'detail/:id', component: EmployeeDetailComponent, canActivate: [AdminGuard] }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeesRoutingModule { }
