import { Component, OnInit } from '@angular/core';

@Component({
  template: `
    <h2>Employees</h2>
    <router-outlet></router-outlet>
  `,
  styles: [`
    h2 {
      padding: 15px; text-align: center; color: #48B; font-family: 'Spartan', sans-serif;
    {
  `]
})
export class EmployeesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

  }
}
