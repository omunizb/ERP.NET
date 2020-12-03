import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Color, BaseChartDirective, Label } from 'ng2-charts';
import { StatsService } from '../stats.service';

@Component({
  selector: 'app-stats-graph',
  templateUrl: './stats-graph.component.html',
  styleUrls: ['./stats-graph.component.css']
})
export class StatsGraphComponent implements OnInit {
  public lineChartData: ChartDataSets[] = [
    { data: this.getUnits()/*[2800, 4800, 4000, 2900, 8600, 9000, 2700]*/, label: 'units sold per month' },
    { data: this.getRevenue()/*[18000, 48000, 43000, 19000, 100000, 85000, 27000]*/, label: 'monthly revenues (USD)', yAxisID: 'y-axis-1' }
  ];
  public lineChartLabels: Label[] = this.getLabels();//['January', 'February', 'March', 'April', 'May', 'June', 'July'];
  public lineChartOptions: (ChartOptions) = {
    responsive: true,
    scales: {
      // We use this empty structure as a placeholder for dynamic theming.
      xAxes: [{}],
      yAxes: [
        {
          id: 'y-axis-0',
          position: 'left',
          scaleLabel: {
            display: true,
            labelString: 'Sales (units)'
          },
          ticks: {
            min: 0
          }
        },
        {
          id: 'y-axis-1',
          position: 'right',
          gridLines: {
            color: 'rgba(103,58,183,0.4)',
          },
          ticks: {
            fontColor: 'rgba(103,58,183,1)',
          },
          scaleLabel: {
            display: true,
            labelString: 'Revenues (USD)'
          }
        }
      ]
    },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };
  public lineChartColors: Color[] = [
    { // grey
      backgroundColor: 'rgba(148,159,177,0.8)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    { // deep-purple
      backgroundColor: 'rgba(103,58,183,0.8)',
      borderColor: 'rgba(103,58,183,1)',
      pointBackgroundColor: 'rgba(103,58,183,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(103,58,183,0.8)'
    }
  ];
  public lineChartLegend = true;
  public lineChartType: ChartType = 'bar';
  // public lineChartPlugins = [pluginAnnotations];

  @ViewChild(BaseChartDirective, { static: true }) chart: BaseChartDirective;

  constructor(
    private router: Router,
    private statsService: StatsService
  ) { }

  ngOnInit(): void {
  }

  getLabels(): Label[] {
    var labels = [];
    this.statsService.getMonthlySales()
    .subscribe(sales => sales.forEach(s => labels.push(s.label)));
    return labels;
  }

  getUnits(): number[] {
    var units = [];
    this.statsService.getMonthlySales()
    .subscribe(sales => sales.forEach(s => units.push(s.units)));
    return units;
  }

  getRevenue(): number[] {
    var revenue = [];
    this.statsService.getMonthlySales()
    .subscribe(sales => sales.forEach(s => revenue.push(s.revenue)));
    return revenue;
  }

  // events
  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    this.router.navigate(['/stats/datepicker']);
  }
}
