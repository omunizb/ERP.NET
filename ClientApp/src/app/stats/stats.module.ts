import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StatsComponent } from './stats.component';

import { StatsRoutingModule } from './stats-routing.module';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { StatsGraphComponent } from './stats-graph/stats-graph.component';
import { StatsDatepickerComponent } from './stats-datepicker/stats-datepicker.component';

@NgModule({
  declarations: [StatsComponent, StatsGraphComponent, StatsDatepickerComponent],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    StatsRoutingModule,
    MatDatepickerModule,
    MatNativeDateModule
  ]
})
export class StatsModule { }
