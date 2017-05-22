import { Component, OnInit, ViewChild } from '@angular/core';
import { SamplesService, SamplesOptions } from './samples.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ SamplesService ]
})
export class AppComponent implements OnInit {
  title = 'Samples';
  samples;
  statuses;
  users;
  errorMessage: string;
  @ViewChild('AddSample') private AddSample;
  @ViewChild('SamplesGrid') private SamplesGrid;


  constructor(private samplesService: SamplesService) {}

  ngOnInit() {
    this.getSamples();
    this.getStatuses();
    this.getUsers();
  }

  onAddClick() {
    this.AddSample.showModal();
  }

  onFilter(options: SamplesOptions) {
    this.getSamples(options);
  }

  onSubmitSample(sample) {
    this.samplesService.addSample(sample)
      .subscribe(s => {
        this.getSamples(this.SamplesGrid.samplesOptions);
        this.AddSample.closeModal();
      }, error => this.errorMessage = <any>error);
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

  getUsers() {
    this.samplesService.getUsers()
      .subscribe(users => this.users = users);
  }
}
