import { Component, OnInit, ViewChild } from '@angular/core';
import { SamplesService } from '../samples.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';

@Component({
  selector: 'samples-grid',
  templateUrl: './samples-grid.component.html',
  styleUrls: ['./samples-grid.component.css'],
  providers: [ SamplesService ]
})
export class SamplesGridComponent implements OnInit {
  private samples: any;
  private cache: any;
  private errorMessage: string; 
  @ViewChild(DatatableComponent) table: DatatableComponent;

  constructor(private samplesService: SamplesService) {}

  ngOnInit() {
    this.getSamples();
  }

  getSamples() {
    this.samplesService.getSamples()
      .subscribe(samples => {
        this.cache = [...samples];
        this.samples = samples;
      },
      error =>  this.errorMessage = <any>error);
  }

  updateFilter(event) {
    const val = event.target.value.toLowerCase();

    const cache = this.cache.filter((s) => {
      return s.creator.fullName.toLowerCase().indexOf(val) !== -1 || !val;
    });

    this.samples = cache;
    this.table.offset = 0;
  }
  
}
