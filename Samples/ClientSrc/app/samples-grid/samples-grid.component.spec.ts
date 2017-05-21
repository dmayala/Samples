import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SamplesGridComponent } from './samples-grid.component';

describe('SamplesGridComponent', () => {
  let component: SamplesGridComponent;
  let fixture: ComponentFixture<SamplesGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SamplesGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SamplesGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
