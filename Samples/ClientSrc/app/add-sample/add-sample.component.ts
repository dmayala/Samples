import { Component, OnInit, Input, 
  Output, ViewChild, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'; 

@Component({
  selector: 'add-sample',
  templateUrl: './add-sample.component.html',
  styleUrls: ['./add-sample.component.css']
})
export class AddSampleComponent implements OnInit {
  @Input() users;
  @Input() statuses;
  @Output() onSubmitSample = new EventEmitter();
  @ViewChild('addSampleModal') private addSampleModal;
  myForm: FormGroup;
  submitted: boolean = false;
  constructor(private _fb: FormBuilder) {
    this.myForm = this._fb.group({
      barcode: [null, <any>Validators.required],
      statusId: [null, <any>Validators.required],
      createdBy: [null, <any>Validators.required]
    });
   }

  ngOnInit() {}

  resetState() {
    this.myForm.reset();
    this.submitted = false;
  }

  showModal() {
    this.addSampleModal.show();
  }

  closeModal() {
    this.addSampleModal.hide();
  }

  onSubmit() {
    this.submitted = true;
    if (this.myForm.valid)
      this.onSubmitSample.emit(this.myForm.value);
  }

}
