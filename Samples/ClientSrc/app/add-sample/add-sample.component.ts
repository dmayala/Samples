import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Sample as SampleModel } from '../models/sample';

@Component({
  selector: 'add-sample',
  templateUrl: './add-sample.component.html',
  styleUrls: ['./add-sample.component.css']
})
export class AddSampleComponent implements OnInit {
  @Input() users;
  @Input() statuses;
  @ViewChild('addSampleModal') private addSampleModal;
  sample = {};
  
  constructor() { }

  ngOnInit() {
  }

  showModal() {
    this.addSampleModal.show();
  }

}
