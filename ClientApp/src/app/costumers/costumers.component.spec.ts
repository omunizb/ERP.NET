import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CostumersComponent } from './costumers.component';

describe('CostumersComponent', () => {
  let component: CostumersComponent;
  let fixture: ComponentFixture<CostumersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CostumersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CostumersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
