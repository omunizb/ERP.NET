import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { EmployeesComponent } from './employees.component';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';

import { EmployeesRoutingModule } from './employees-routing.module';

@NgModule({
  declarations: [
    EmployeesComponent,
    EmployeesListComponent,
    EmployeeDetailComponent  
  ],
  imports: [
    EmployeesRoutingModule,
    SharedModule
  ]
})
export class EmployeesModule { }
