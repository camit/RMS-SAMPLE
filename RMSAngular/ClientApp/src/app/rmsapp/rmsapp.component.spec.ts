import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RmsappComponent } from './rmsapp.component';

describe('RmsappComponent', () => {
  let component: RmsappComponent;
  let fixture: ComponentFixture<RmsappComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RmsappComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RmsappComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
