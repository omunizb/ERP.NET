import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StatsComponent } from './stats.component';
import { StatsDatepickerComponent } from './stats-datepicker/stats-datepicker.component';
import { StatsGraphComponent } from './stats-graph/stats-graph.component';

const routes: Routes = [
  { path: '', 
    component: StatsComponent,
    children: [
      { path: '', component: StatsDatepickerComponent },
      { path: 'graph', component: StatsGraphComponent }
    ] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StatsRoutingModule { }
