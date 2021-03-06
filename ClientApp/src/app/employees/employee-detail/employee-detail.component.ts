import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder, Validators } from '@angular/forms';
import { tap } from 'rxjs/operators';

import { EmployeeService } from '../employee.service';
import { Employee } from 'src/app/models';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {
  employeeForm;
  isAdmin: boolean;
  currentEmployee: Employee;

  constructor(
    private employeeService: EmployeeService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.employeeForm = this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: ['', [Validators.required, Validators.maxLength(35)]],
      surname: ['', [Validators.required, Validators.maxLength(35)]],
      email: ['', [Validators.required, Validators.maxLength(320)]],
      hired: [{ value: '', disabled: true }],
      departed: [{ value: '', disabled: true }],
      salary: ['', Validators.required],
      position: ['', [Validators.required, Validators.maxLength(100)]],
    });

    if (this.route.snapshot.paramMap.get('id')) {
      this.getEmployee();
    }

    this.employeeService.getRole().subscribe(r => this.isAdmin = r);
  }

  onSubmit(employeeData) {
    if (this.route.snapshot.paramMap.get('id')) {

      // Merge employeeData (form changes) with currentEmployee to get updatedEmployee 
      let updatedEmployee = {...this.currentEmployee, ...employeeData};

      this.employeeService.updateEmployee(updatedEmployee).subscribe();
    }
    else {
      delete employeeData.id;
      employeeData.hired = new Date();
      employeeData.departed = null;
      this.employeeService.addEmployee(employeeData).subscribe();
    }
    this.router.navigate(['/employees']);
  }

  getEmployee(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id)
      .pipe(tap(employee => this.employeeForm.patchValue(employee)))
      .subscribe(employee => this.currentEmployee = employee);
  }

  goBack(): void {
    this.location.back();
  }
}
