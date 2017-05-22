import { FormControl } from '@angular/forms';

export class CustomValidators {
    static required(control: FormControl) {
         return (typeof control.value === 'string' && control.value.trim() == "") ? { 'required': true } : null;
    }
}