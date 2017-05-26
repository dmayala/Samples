import { Component, OnInit, ViewChild } from '@angular/core';
import { SamplesService, SamplesOptions } from './samples.service';
import { Toast, ToasterService} from 'angular2-toaster';

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
  isFetchingSamples: boolean;
  errorMessage: string;
  @ViewChild('AddSample') private AddSample;
  @ViewChild('SamplesGrid') private SamplesGrid;


  constructor(private samplesService: SamplesService, private toasterService: ToasterService) {}

  ngOnInit() {
    this.getSamples();
    this.getStatuses();
    this.getUsers();
  }

  onAddClick(e) {
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
        this.toasterService.pop({ type: 'success', body: 'Your sample has been added.' } as Toast)
      }, error => {
        this.errorMessage = <any>error;
        this.toasterService.pop({ type: 'error', body: 'Failed to add new sample.' } as Toast)
      });
  }

  getSamples(options?: SamplesOptions) {
    this.isFetchingSamples = true;
    this.samplesService.getSamples(options)
      .finally(() => this.isFetchingSamples = false)
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
