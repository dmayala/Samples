import { Component, OnInit } from '@angular/core';
import { SamplesService } from '../samples.service';

@Component({
  selector: 'samples-grid',
  templateUrl: './samples-grid.component.html',
  styleUrls: ['./samples-grid.component.css'],
  providers: [ SamplesService ]
})
export class SamplesGridComponent implements OnInit {
  private samples: Object[];
  private errorMessage: string; 

  constructor(private samplesService: SamplesService) {}

  ngOnInit() {
    this.getSamples();
  }

  getSamples() {
    this.samplesService.getSamples()
      .subscribe(samples => this.samples = samples,
                 error =>  this.errorMessage = <any>error);
  }
  
}
