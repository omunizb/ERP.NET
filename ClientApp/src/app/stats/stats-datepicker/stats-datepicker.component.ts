import { Component, OnInit } from '@angular/core';
import { DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from '../datepicker-format';

import { StatsService } from '../stats.service';

@Component({
  selector: 'app-stats-datepicker',
  templateUrl: './stats-datepicker.component.html',
  styleUrls: ['./stats-datepicker.component.css'],
  providers: [
    {provide: DateAdapter, useClass: AppDateAdapter},
    {provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS}
  ]
})
export class StatsDatepickerComponent implements OnInit {
  date: Date;
  stats: number[] = [0, 0];
  minDate: Date;
  maxDate: Date;

  constructor(private statsService: StatsService) { }

  ngOnInit(): void {
    const currentYear = new Date().getFullYear();
    const currentMonth = new Date().getMonth();
    this.minDate = new Date(2015, 0, 1);
    this.maxDate = new Date(currentYear, (currentMonth - 1) % 12, 1);
    this.date = this.maxDate;
  }

  chosenMonthHandler(eventData: Date, picker?: any) {
    this.date = eventData;
    this.getStats(eventData);
    picker.close();
  }

  getStats(date: Date) {
    this.statsService.getStats(date)
    .subscribe(stats => this.stats = stats);
  }
}
