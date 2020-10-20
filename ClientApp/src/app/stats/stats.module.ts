import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StatsComponent } from './stats.component';

import { StatsRoutingModule } from './stats-routing.module';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [StatsComponent],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    StatsRoutingModule,
    MatDatepickerModule,
    MatNativeDateModule
  ]
})
export class StatsModule { }
