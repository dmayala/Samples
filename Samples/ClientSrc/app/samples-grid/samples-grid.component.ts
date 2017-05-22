import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { FormControl } from '@angular/forms';
import { SamplesOptions } from '../samples.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';

import 'rxjs/add/operator/debounceTime';

@Component({
  selector: 'samples-grid',
  templateUrl: './samples-grid.component.html',
  styleUrls: ['./samples-grid.component.css'],
  providers: []
})
export class SamplesGridComponent implements OnInit {
  private _samples: any;
  @Input()
  public set samples(val) {
    this._samples = val;
    this.table.offset = 0;
  }
  public get samples() { return this._samples; }
  @Input() statuses;
  @Output() onFilter = new EventEmitter();
  @ViewChild(DatatableComponent) table: DatatableComponent;
  nameControl: FormControl = new FormControl();
  statusControl: FormControl = new FormControl('');

  private samplesOptions: SamplesOptions = {};

  constructor() {}

  ngOnInit() {
    this.nameControl.valueChanges
      .debounceTime(500)
      .subscribe(e => this.updateNameFilter(e));
  }

  getSamples(options?: SamplesOptions) {
    this.onFilter.emit(options);
  }

  updateNameFilter(newValue) {
    this.samplesOptions.name = newValue.toLowerCase();
    this.getSamples(this.samplesOptions);
  }

  updateStatusFilter(newValue) {
    this.samplesOptions.status = newValue;
    this.getSamples(this.samplesOptions);
  }
  
  resetFilters() {
    this.samplesOptions = {};
    this.nameControl.setValue('');
    this.statusControl.setValue('');
    this.getSamples();
  }
}
