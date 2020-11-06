import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatsDatepickerComponent } from './stats-datepicker.component';

describe('StatsDatepickerComponent', () => {
  let component: StatsDatepickerComponent;
  let fixture: ComponentFixture<StatsDatepickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatsDatepickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatsDatepickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
