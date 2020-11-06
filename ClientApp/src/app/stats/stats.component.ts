import { Component, OnInit } from '@angular/core';

@Component({
  template: `
    <h2>Statistics</h2>
    <router-outlet></router-outlet>
  `,
  styles: [`
    h2 {
      padding: 15px; text-align: center; color: #48B; font-family: 'Spartan', sans-serif;
    {
  `]
})
export class StatsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

  }
}
