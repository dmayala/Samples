import { Component, OnInit } from '@angular/core';
import { SamplesService, SamplesOptions } from './samples.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ SamplesService ]
})
export class AppComponent implements OnInit {
  title = 'Samples';
  samples: any;
  statuses: any;
  errorMessage: string;

  constructor(private samplesService: SamplesService) {}

  ngOnInit() {
    this.getSamples();
    this.getStatuses();
  }

  onFilter(options: SamplesOptions) {
    this.getSamples(options);
  }

  getSamples(options?: SamplesOptions) {
    this.samplesService.getSamples(options)
      .subscribe(samples => this.samples = samples,
                 error =>  this.errorMessage = <any>error);
  }

  getStatuses() {
    this.samplesService.getStatuses()
      .subscribe(statuses => this.statuses = statuses);
  }
}
